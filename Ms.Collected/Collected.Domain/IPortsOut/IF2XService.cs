using Collected.Domain.Models.Services;

namespace Collected.Domain.IPortsOut
{
    public interface IF2XService
    {
        Task<List<ConteoVehiculosDto>?> GetConteoVehiculos(string Fecha);
        Task<List<RecaudoVehiculosDto>?> GetRecaudoVehiculos(string Fecha);
    }
}
