using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PointManagement_Application.DTOs;
using System.Runtime.CompilerServices;

namespace PointManagement_Application.Helper
{
    public static class ApiHelper
    {
        private static readonly HttpClient client = new HttpClient();

        static ApiHelper()
        {
            client.BaseAddress = new Uri("https://localhost:5000/api/"); // Phải khớp với Url của Be
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static async Task<T> GetDataAsync<T>(string endpoint)
        {
            var response = await client.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            var jsonResult = await response.Content.ReadAsStringAsync();

            var jsonObject = JObject.Parse(jsonResult);
            if (jsonObject["data"] != null)
            {
                var data = jsonObject["data"].ToString();
                return JsonConvert.DeserializeObject<T>(data);
            }

            return JsonConvert.DeserializeObject<T>(jsonResult);
        }

        public static async Task<T> GetAsync<T>(string endpoint, string token = null, bool isMethod = false)
        {
            if (isMethod && !string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var response = await client.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            var jsonResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResult);
        }
        public static async Task<T> DeleteAsync<T>(string endpoint)
        {
            var response = await client.DeleteAsync(endpoint);
            response.EnsureSuccessStatusCode();

            var jsonResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResult);
        }
        public static async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data, string token = null , bool isMethod = false)
        {
            var jsonContent = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            if (isMethod && !string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
            var response = await client.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode();

            var jsonResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(jsonResult);
        }

        public static async Task<TResponse> PutAsync<TRequest, TResponse>(string endpoint, TRequest data, string token = null, bool isMethod = false)
        {
            var jsonContent = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            if (isMethod && !string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var response = await client.PutAsync(endpoint, content);
            response.EnsureSuccessStatusCode();

            var jsonResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(jsonResult);
        }
        public static async Task<ServiceResponse<string>> PostAuthAsync<TRequest>(string endpoint, TRequest data)
        {
            var jsonContent = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(endpoint, content);
                var jsonResult = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {

                    var errorResponse = JsonConvert.DeserializeObject<ServiceResponse<string>>(jsonResult);
                    return new ServiceResponse<string>
                    {
                        Success = false,
                        Message = errorResponse?.Message ?? "Login failed."
                    };
                }

                // If successful, deserialize and return the token data as usual
                var successResponse = JsonConvert.DeserializeObject<ServiceResponse<string>>(jsonResult);
                return new ServiceResponse<string>
                {
                    Success = true,
                    Data = successResponse.Data
                };
            }
            catch (HttpRequestException ex)
            {

                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = $"Network error: {ex.Message}"
                };
            }
        }
    }
}
