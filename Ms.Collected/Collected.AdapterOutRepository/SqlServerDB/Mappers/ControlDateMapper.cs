using Collected.AdapterOutRepository.SqlServerDB.Entities;
using Collected.Domain.Models.Services;

namespace Collected.AdapterOutRepository.SqlServerDB.Mappers
{
    public static class ControlDateMapper
    {
        public static ControlDateDto? ToDomain(this ControlDate controlDateEntity)
        {
            ControlDateDto collectedDto = new()
            {
                Id = controlDateEntity.Id,
                fecha = controlDateEntity.fecha,
                ultima_ejecucion = controlDateEntity.ultima_ejecucion,
                en_ejecucion = controlDateEntity.en_ejecucion
            };
            return collectedDto ?? null;
        }

        public static ControlDate ToEntity(this ControlDateDto controlDateDto)
        {
            return new ControlDate
            {
                Id = controlDateDto.Id,
                fecha = controlDateDto.fecha,
                ultima_ejecucion = controlDateDto.ultima_ejecucion,
                en_ejecucion = controlDateDto.en_ejecucion
            };
        }
    }
}
