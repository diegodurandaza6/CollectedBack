using Collected.AdapterOutRepository.SqlServerDB.Entities;
using Collected.Domain.Models.Services;

namespace Collected.AdapterOutRepository.SqlServerDB.Mappers
{
    public static class JwtAuthMapper
    {
        public static JwtAuthDto? ToDomain(this JwtAuth jwtAuthEntity)
        {
            JwtAuthDto jwtAuthDto = new()
            {
                Id = jwtAuthEntity.Id,
                token = jwtAuthEntity.token,
                expiration = jwtAuthEntity.expiration
            };
            return jwtAuthDto ?? null;
        }

        public static JwtAuth ToEntity(this JwtAuthDto jwtAuthDto)
        {
            return new JwtAuth
            {
                Id = jwtAuthDto.Id,
                token = jwtAuthDto.token,
                expiration = jwtAuthDto.expiration
            };
        }
    }
}
