using Collected.Domain.Models.Services;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Collected.AdapterOutF2XService.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private string _accessToken;
        private DateTime _accessTokenExpiration;

        public ApiClient(string baseUrl)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public async Task<bool> LoginAsync(string Method, string userName, string password)
        {
            var loginModel = new
            {
                userName,
                password
            };

            var response = await _httpClient.PostAsJsonAsync(Method, loginModel);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<JwtAuthDto>();
                if(result != null)
                {
                    _accessToken = result.token;
                    _accessTokenExpiration = result.expiration;
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                    return true;
                }else
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<T> GetDataAsync<T>(string endpoint)
        {
            if (DateTime.Now >= _accessTokenExpiration)
            {
                ///ToDO:
                // Token expirado, intenta refrescar el token o solicitar uno nuevo
                // y actualizar _accessToken y _accessTokenExpiration
                // Esto depende de cómo implementaste la renovación de tokens en tu API
            }

            var response = await _httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<T>();
                return result;
            }

            return default;
        }
    }

}
