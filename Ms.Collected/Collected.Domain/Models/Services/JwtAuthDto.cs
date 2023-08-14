namespace Collected.Domain.Models.Services
{
    public record JwtAuthDto (string token, DateTime expiration)
    {
    }
}
