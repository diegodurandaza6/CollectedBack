
using Collected.Domain.IPortsOut;
using Collected.Domain.Models.Services;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Json;

namespace Collected.AdapterOutF2XService.Services
{
    public class F2XService : IF2XService
    {
        private readonly IConfiguration _configuration;
        private readonly ICollectedRepository _collectedRepository;

        public F2XService(IConfiguration configuration, ICollectedRepository collectedRepository)
        {
            _configuration = configuration;
            _collectedRepository = collectedRepository;
        }

        public async Task<List<ConteoVehiculosDto>?> GetConteoVehiculos(string Fecha)
        {   
            string? ConteoMethod = _configuration.GetSection("ApiF2X:ConteoMethod").Value;
            List<ConteoVehiculosDto> Data = await GetDataAsync<List<ConteoVehiculosDto>>(string.Format("{0}/{1}", ConteoMethod, Fecha));
            return Data;
        }

        public async Task<List<RecaudoVehiculosDto>?> GetRecaudoVehiculos(string Fecha)
        {
            string? RecaudoMethod = _configuration.GetSection("ApiF2X:RecaudoMethod").Value;
            List<RecaudoVehiculosDto> Data = await GetDataAsync<List<RecaudoVehiculosDto>>(string.Format("{0}/{1}", RecaudoMethod, Fecha));
            return Data;
        }

        private async Task<T> GetDataAsync<T>(string endpoint)
        {
            string baseUrl = _configuration.GetSection("ApiF2X:baseUrl").Value;
            var jwtAuth = _collectedRepository.GetToken();
            if (jwtAuth == null || DateTime.Now >= jwtAuth.expiration.AddMinutes(-5))
            {
                string method = _configuration.GetSection("ApiF2X:methodLogin").Value;
                string username = _configuration.GetSection("ApiF2X:usrLogin").Value;
                string password = _configuration.GetSection("ApiF2X:pwdLogin").Value;

                jwtAuth = await LoginAsync(baseUrl, method, username, password);
                if (jwtAuth == null)
                {
                    return default;
                }
            }
            HttpClient _httpClient = new()
            {
                BaseAddress = new Uri(baseUrl)
            };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtAuth.token);
            var response = await _httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<T>();
                return result;
            }

            return default;
        }

        private async Task<JwtAuthDto?> LoginAsync(string BaseUrl, string Method, string userName, string password)
        {
            var loginModel = new
            {
                userName,
                password
            };

            HttpClient _httpClient = new()
            {
                BaseAddress = new Uri(BaseUrl)
            };
            var response = await _httpClient.PostAsJsonAsync(Method, loginModel);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<JwtAuthDto>();
                if (result != null)
                {
                    JwtAuthDto jwtAuthDto = new()
                    {
                        token = result.token,
                        expiration = result.expiration
                    };
                    _collectedRepository.ManageToken(jwtAuthDto);
                    return jwtAuthDto;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
    }
}
