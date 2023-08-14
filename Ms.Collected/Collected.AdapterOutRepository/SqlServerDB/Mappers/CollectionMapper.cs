using Collected.Domain.Models;

namespace Collected.AdapterOutRepository.SqlServerDB.Mappers
{
    public static class CollectionMapper
    {
        public static IEnumerable<CollectionDto?>? ToDomainIterable(this IEnumerable<Entities.Recaudos> enumerableEntity)
        {
            return enumerableEntity.Select(x => x.ToDomain());
        }

        public static CollectionDto? ToDomain(this Entities.Recaudos collectionEntity)
        {
            CollectionDto collectedDto = new()
            {
                Id = collectionEntity.Id,
                Station = collectionEntity.Estacion,
                Way = collectionEntity.Sentido,
                Hour = collectionEntity.Hora,
                Category = collectionEntity.Categoria,
                Amount = collectionEntity.Cantidad,
                TabulatedValue = collectionEntity.ValorTabulado,
                Date = collectionEntity.Fecha.ToString("yyyy-MM-dd")
            };
            return collectedDto ?? null;
        }

        public static Entities.Recaudos ToEntity(this CollectionDto collectionDto)
        {
            return new Entities.Recaudos
            {
                Id = collectionDto.Id,
                Estacion = collectionDto.Station,
                Sentido = collectionDto.Way,
                Hora = collectionDto.Hour,
                Categoria = collectionDto.Category,
                Cantidad = collectionDto.Amount,
                ValorTabulado = collectionDto.TabulatedValue,
                Fecha = DateTime.Parse(collectionDto.Date)
            };
        }
    }
}
