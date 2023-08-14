using Collected.Domain.Models;
using Collected.Domain.Models.Services;

namespace Collected.Application.UseCases
{
    public class CollectedUseCase
    {
        public static List<CollectionDto> GetDataToSaveOnDB(List<ConteoVehiculosDto> conteoData, List<RecaudoVehiculosDto> recaudoData, string Fecha)
        {

            List<CollectionDto> dataResult = new();

            conteoData.ForEach(data =>
            {
                if(dataResult.Any(dr => 
                    dr.Station == data.Estacion && 
                    dr.Way == data.Sentido &&
                    dr.Hour == data.Hora &&
                    dr.Category == data.Categoria &&
                    dr.Date == Fecha)
                )
                {
                    dataResult.Find(dr =>
                    dr.Station == data.Estacion &&
                    dr.Way == data.Sentido &&
                    dr.Hour == data.Hora &&
                    dr.Category == data.Categoria &&
                    dr.Date == Fecha).Amount += data.Cantidad;
                }
                else
                {
                    dataResult.Add(
                        new CollectionDto
                        {
                            Station = data.Estacion,
                            Way = data.Sentido,
                            Hour = data.Hora,
                            Category = data.Categoria,
                            Amount = data.Cantidad ?? 0,
                            TabulatedValue = 0,
                            Date = Fecha
                        }
                    );
                }
            });

            recaudoData.ForEach(data =>
            {
                if (dataResult.Any(dr =>
                    dr.Station == data.Estacion &&
                    dr.Way == data.Sentido &&
                    dr.Hour == data.Hora &&
                    dr.Category == data.Categoria &&
                    dr.Date == Fecha)
                )
                {
                    dataResult.Find(dr =>
                    dr.Station == data.Estacion &&
                    dr.Way == data.Sentido &&
                    dr.Hour == data.Hora &&
                    dr.Category == data.Categoria &&
                    dr.Date == Fecha).TabulatedValue += data.ValorTabulado;
                }
                else
                {
                    dataResult.Add(
                        new CollectionDto
                        {
                            Station = data.Estacion,
                            Way = data.Sentido,
                            Hour = data.Hora,
                            Category = data.Categoria,
                            Amount = 0,
                            TabulatedValue = data.ValorTabulado ?? 0,
                            Date = Fecha
                        }
                    );
                }
            });

            return dataResult;
        }

    }
}
