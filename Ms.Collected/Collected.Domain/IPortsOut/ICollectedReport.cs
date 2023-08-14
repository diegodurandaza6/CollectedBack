
using System.Data;

namespace Collected.Domain.IPortsOut
{
    public interface ICollectedReport
    {
        byte[] GetReport(DataTable data);
    }
}
