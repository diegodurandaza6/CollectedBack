namespace Collected.Domain.Models.Services
{
    public record ConteoVehiculosDto (string Estacion, string Sentido, byte Hora, string Categoria, int? Cantidad)
    {
    }
}
