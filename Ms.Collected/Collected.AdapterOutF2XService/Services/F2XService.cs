
using Collected.Domain.IPortsOut;
using Collected.Domain.Models.Services;
using Microsoft.Extensions.Configuration;

namespace Collected.AdapterOutF2XService.Services
{
    public class F2XService : IF2XService
    {
        private readonly IConfiguration _configuration;

        public F2XService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<ConteoVehiculosDto>?> GetConteoVehiculos(string Fecha)
        {
            string baseUrl = _configuration.GetSection("ApiF2X:baseUrl").Value;
            var apiClient = new ApiClient(baseUrl);

            //string method = _configuration.GetSection("ApiF2X:methodLogin").Value;
            //string username = _configuration.GetSection("ApiF2X:usrLogin").Value;
            //string password = _configuration.GetSection("ApiF2X:pwdLogin").Value;

            //var loggedIn = await apiClient.LoginAsync(method, username, password);

            //if (loggedIn)
            //{
                string ConteoMethod = _configuration.GetSection("ApiF2X:ConteoMethod").Value;
                //List<ConteoVehiculosDto> Data = await apiClient.GetDataAsync<List<ConteoVehiculosDto>>(string.Format("{0}/{1}", ConteoMethod, Fecha));
                List<ConteoVehiculosDto> Data = await apiClient.GetDataAsync<List<ConteoVehiculosDto>>(ConteoMethod);
            return Data;
            //}
            //else
            //{
            //    return null;
            //}
        }

        public async Task<List<RecaudoVehiculosDto>?> GetRecaudoVehiculos(string Fecha)
        {
            string baseUrl = _configuration.GetSection("ApiF2X:baseUrl").Value;
            var apiClient = new ApiClient(baseUrl);

            string RecaudoMethod = _configuration.GetSection("ApiF2X:RecaudoMethod").Value;
            //List<RecaudoVehiculosDto> Data = await apiClient.GetDataAsync<List<RecaudoVehiculosDto>>(string.Format("{0}/{1}", RecaudoMethod, Fecha));
            List<RecaudoVehiculosDto> Data = await apiClient.GetDataAsync<List<RecaudoVehiculosDto>>(RecaudoMethod);
            return Data;
        }
    }
}
