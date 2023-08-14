using Collected.Domain.Models;

namespace Collected.Domain.IPortsIn
{
    public interface ICollectedService
    {
        Task<IEnumerable<CollectionDto?>?> GetCollected();
        byte[] GetReport();
        Task CreateCollected();
    }
}
