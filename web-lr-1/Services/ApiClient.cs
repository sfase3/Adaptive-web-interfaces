using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using LR1.Models;

namespace LR1.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<string>> Get(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var responseData = await response.Content.ReadAsStringAsync();

                return new ApiResponse<string>
                {
                    Message = "Success",
                    HttpStatusCode = (int)response.StatusCode,
                    Data = new List<string> { responseData } 
                };
            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse<string>
                {
                    Message = ex.Message,
                    HttpStatusCode = 500,
                    Data = null
                };
            }
        }

        public async Task<ApiResponse<string>> Post(string url, string content)
        {
            try
            {
                var httpContent = new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded");
                var response = await _httpClient.PostAsync(url, httpContent);
                response.EnsureSuccessStatusCode();

                var responseData = await response.Content.ReadAsStringAsync();

                return new ApiResponse<string>
                {
                    Message = "Success",
                    HttpStatusCode = (int)response.StatusCode,
                    Data = new List<string> { responseData } 
                };
            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse<string>
                {
                    Message = ex.Message,
                    HttpStatusCode = 500,
                    Data = null
                };
            }
        }

    }
}
