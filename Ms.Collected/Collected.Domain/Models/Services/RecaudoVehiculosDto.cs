namespace Collected.Domain.Models.Services
{
    public record RecaudoVehiculosDto(string Estacion, string Sentido, byte Hora, string Categoria, decimal? ValorTabulado)
    {
    }
}
