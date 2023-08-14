using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Security.Application.Utilities;
using Security.Domain.IPortsIn;
using Security.Domain.IPortsOut;
using Security.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Security.Application
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsersDbMock _usersDbMock;

        public LoginService(IConfiguration configuration, IUsersDbMock usersDbMock)
        {
            _configuration = configuration;
            _usersDbMock = usersDbMock;
        }

        public UserModelDto? Authenticate(UserLoginDto login)
        {
            CipherHelper _helper = new(_configuration["Encrypt:Key"], _configuration["Encrypt:IV"]);
            UserModelDto? currentUser = _usersDbMock.GetUsersDb().FirstOrDefault(
                u => u.UserName.ToLower() == login.UserName.ToLower() && u.Password == _helper.Encrypt(login.Password)
            );
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }

        public ResponseTokenDto GenerateToken(UserModelDto user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Rol),
            };
            DateTime expiresDate = DateTime.Now.AddMinutes(double.Parse(_configuration["Jwt:ExpiresMinutes"]));
            var secutiryToken = new JwtSecurityToken(
                claims: claims,
                expires: expiresDate,
                signingCredentials: credentials);
            ResponseTokenDto result = new(new JwtSecurityTokenHandler().WriteToken(secutiryToken), expiresDate);
            return result;
        }
    }
}
