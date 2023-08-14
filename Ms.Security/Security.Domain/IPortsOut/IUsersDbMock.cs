using Security.Domain.Models;

namespace Security.Domain.IPortsOut
{
    public interface IUsersDbMock
    {
        List<UserModelDto> GetUsersDb();
    }
}
