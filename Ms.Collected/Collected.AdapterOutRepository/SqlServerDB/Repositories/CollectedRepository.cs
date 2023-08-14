using Microsoft.EntityFrameworkCore;
using Collected.AdapterOutRepository.SqlServerDB.Mappers;
using Collected.Domain.IPortsOut;
using Collected.Domain.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Collected.Domain.Models.Services;
using Microsoft.Extensions.Configuration;
using Collected.AdapterOutRepository.SqlServerDB.Entities;

namespace Collected.AdapterOutRepository.SqlServerDB.Repositories
{
    public class CollectedRepository : ICollectedRepository
    {
        private readonly DiegoDBContext _dbContext;
        private readonly IConfiguration _configuration;
        public CollectedRepository(DiegoDBContext diegoDBContext, IConfiguration configuration) {
            _dbContext = diegoDBContext;
            _configuration = configuration;
        }

        public void CreateCollected(List<CollectionDto> collected)
        {
            try
            {
                _dbContext.Database.SetCommandTimeout(6000);
                collected.ForEach(item =>
                {
                    var existingItem = _dbContext.Recaudos
                        .FirstOrDefault(r =>
                            r.Estacion == item.Station &&
                            r.Sentido == item.Way &&
                            r.Hora == item.Hour &&
                            r.Categoria == item.Category &&
                            r.Fecha == DateTime.Parse(item.Date)
                        );

                    if (existingItem != null)
                    {
                        existingItem.Cantidad = item.Amount;
                        existingItem.ValorTabulado = item.TabulatedValue;

                        _dbContext.Entry(existingItem).State = EntityState.Modified;
                    }
                    else
                    {
                        _dbContext.Recaudos.Add(item.ToEntity());
                    }

                    _dbContext.SaveChanges();
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<IEnumerable<CollectionDto?>?> GetCollected()
        {
            try
            {
                IQueryable<Recaudos> query = _dbContext.Recaudos.AsQueryable();
                var result = await query.ToListAsync();
                return result?.ToDomainIterable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetReportDataTable()
        {
            var dataTable = new DataTable();

            using (var connection = _dbContext.Database.GetDbConnection() as SqlConnection)
            {
                connection.Open();

                using var command = connection.CreateCommand();
                command.CommandText = "GetDataCollected";
                command.CommandType = CommandType.StoredProcedure;

                using var reader = command.ExecuteReader();
                dataTable.Load(reader);
            }

            return dataTable;
        }

        public ControlDateDto GetControlDate()
        {
            try
            {
                ControlDate? controlDate = _dbContext.ControlDate.FirstOrDefault();
                if (controlDate == null)
                {
                    controlDate = new()
                    {
                        fecha = DateTime.Parse(_configuration.GetSection("ApiF2X:FechaDefault").Value),
                        ultima_ejecucion = DateTime.UtcNow.AddHours(-5),
                    };
                }
                return controlDate.ToDomain();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateControlDate(ControlDateDto controlDateDto)
        {
            try
            {
                var existingItem = _dbContext.ControlDate.FirstOrDefault();

                if (existingItem != null)
                {
                    existingItem.fecha = controlDateDto.fecha;
                    existingItem.ultima_ejecucion = controlDateDto.ultima_ejecucion;
                    existingItem.en_ejecucion = controlDateDto.en_ejecucion;

                    _dbContext.Entry(existingItem).State = EntityState.Modified;
                }
                else
                {
                    _dbContext.ControlDate.Add(controlDateDto.ToEntity());
                }

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
