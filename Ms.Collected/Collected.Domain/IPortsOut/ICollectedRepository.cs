using Collected.Domain.Models;
using Collected.Domain.Models.Services;
using System.Data;

namespace Collected.Domain.IPortsOut
{
    public interface ICollectedRepository
    {
        Task<IEnumerable<CollectionDto?>?> GetCollected();
        DataTable GetReportDataTable();
        void CreateCollected(List<CollectionDto> collected);
        ControlDateDto GetControlDate();
        void UpdateControlDate(ControlDateDto controlDateDto);
        JwtAuthDto? GetToken();
        void ManageToken(JwtAuthDto jwtAuthDto);
    }
}
