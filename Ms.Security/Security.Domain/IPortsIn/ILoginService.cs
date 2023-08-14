using Security.Domain.Models;

namespace Security.Domain.IPortsIn
{
    public interface ILoginService
    {
        UserModelDto? Authenticate(UserLoginDto login);
        ResponseTokenDto GenerateToken(UserModelDto user);
    }
}
