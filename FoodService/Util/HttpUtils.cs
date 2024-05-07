using FoodService.Nuget.Models;
using System.Text.Json;

namespace FoodService.Util
{
    public static class HttpUtils
    {
        public static async Task<ResponseCommon<T>> HandleResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var responseObject = JsonSerializer.Deserialize<T>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return ResponseCommon<T>.Success(responseObject!);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                return FailedRequest<T>(errorMessage, (int)response.StatusCode);
            }
        }
        public static ResponseCommon<T> FailedRequest<T>(string errorMessage, int statusCode)
        {
            return ResponseCommon<T>.Failure("Failed to make request", statusCode, errorMessage);
        }
    }
}
