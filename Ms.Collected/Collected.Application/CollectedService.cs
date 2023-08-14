using Collected.Application.Exceptions;
using Collected.Application.UseCases;
using Collected.Domain.IPortsIn;
using Collected.Domain.IPortsOut;
using Collected.Domain.Models;
using Collected.Domain.Models.Services;
using System.Data;

namespace Collected.Application
{
    public class CollectedService : ICollectedService
    {
        private readonly ICollectedRepository _collectedRepository;
        private readonly ICollectedReport _collectedReport;
        private readonly IF2XService _f2xService;

        public CollectedService(
            ICollectedRepository collectedRepository,
            ICollectedReport collectedReport,
            IF2XService f2xService
        )
        {
            _collectedRepository = collectedRepository;
            _collectedReport = collectedReport;
            _f2xService = f2xService;
        }

        public async Task<IEnumerable<CollectionDto?>?> GetCollected()
        {
            return await _collectedRepository.GetCollected();
        }

        public byte[] GetReport()
        {
            DataTable data = _collectedRepository.GetReportDataTable();
            return _collectedReport.GetReport(data);
        }

        public async Task CreateCollected()
        {
            ControlDateDto objControl = _collectedRepository.GetControlDate();
            if (!objControl.en_ejecucion)
            {
                while(objControl.fecha.Date <= DateTime.Now.Date)
                {
                    string FechaControl = objControl.fecha.ToString("yyyy-MM-dd");
                    List<ConteoVehiculosDto> ConteoLista = await _f2xService.GetConteoVehiculos(FechaControl);
                    List<RecaudoVehiculosDto> RecaudoLista = await _f2xService.GetRecaudoVehiculos(FechaControl);

                    List<CollectionDto> data = CollectedUseCase.GetDataToSaveOnDB(ConteoLista, RecaudoLista, FechaControl);
                    objControl.fecha = objControl.fecha.AddDays(1);
                    objControl.ultima_ejecucion = DateTime.Now;
                    objControl.en_ejecucion = true;
                    if (data.Any())
                    {
                        _collectedRepository.CreateCollected(data);
                        _collectedRepository.UpdateControlDate(objControl);
                    }
                }
                objControl.en_ejecucion = false;
                _collectedRepository.UpdateControlDate(objControl);
            }
        }

    }
}
