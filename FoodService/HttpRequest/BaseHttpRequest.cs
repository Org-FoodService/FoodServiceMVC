using System.Net;
using System.Text;
using System.Text.Json;
using FoodService.Models;

namespace FoodService.HttpRequest
{
    /// <summary>
    /// Base class for making HTTP requests.
    /// </summary>
    /// <typeparam name="C">The type of the class inheriting from BaseHttpRequest.</typeparam>
    public class BaseHttpRequest<C>
    {
        private readonly HttpClient _httpClient;
        public readonly ILogger<C> _logger;

        /// <summary>
        /// Initializes a new instance of the BaseHttpRequest class.
        /// </summary>
        /// <param name="baseUrl">The base URL of the HTTP requests.</param>
        /// <param name="logger">The logger instance.</param>
        public BaseHttpRequest(string baseUrl, ILogger<C> logger)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUrl.TrimEnd('/'));
            _logger = logger;
        }

        /// <summary>
        /// Sends a POST request.
        /// </summary>
        /// <typeparam name="T">The type of the response data.</typeparam>
        /// <param name="url">The URL to which the request is sent.</param>
        /// <param name="data">The data to be sent with the request.</param>
        /// <param name="useCryptoToken">Specifies whether to use a cryptographic token for authorization.</param>
        /// <returns>A task representing the asynchronous operation and containing the response.</returns>
        public async Task<ResponseCommon<T>> PostAsync<T>(string url, object data, bool useCryptoToken = false)
        {
            try
            {
                _logger.LogInformation($"Sending POST request to: {_httpClient.BaseAddress}/{url}");
                var content = CreateJsonContent(data);
                AddAuthorizationHeader(useCryptoToken);
                var response = await _httpClient.PostAsync(url, content);
                return await HandleResponse<T>(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error sending POST request to: {_httpClient.BaseAddress}/{url}");
                return FailedRequest<T>("Failed to send POST request", 500);
            }
        }

        /// <summary>
        /// Sends a GET request.
        /// </summary>
        /// <typeparam name="T">The type of the response data.</typeparam>
        /// <param name="url">The URL to which the request is sent.</param>
        /// <param name="useCryptoToken">Specifies whether to use a cryptographic token for authorization.</param>
        /// <returns>A task representing the asynchronous operation and containing the response.</returns>
        public async Task<ResponseCommon<T>> GetAsync<T>(string url, bool useCryptoToken = false)
        {
            try
            {
                _logger.LogInformation($"Sending GET request to: {_httpClient.BaseAddress}/{url}");
                AddAuthorizationHeader(useCryptoToken);
                var response = await _httpClient.GetAsync(url);
                return await HandleResponse<T>(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error sending GET request to: {_httpClient.BaseAddress}/{url}");
                return FailedRequest<T>("Failed to send GET request", 500);
            }
        }

        /// <summary>
        /// Sends a PUT request.
        /// </summary>
        /// <typeparam name="T">The type of the response data.</typeparam>
        /// <param name="url">The URL to which the request is sent.</param>
        /// <param name="data">The data to be sent with the request.</param>
        /// <param name="useCryptoToken">Specifies whether to use a cryptographic token for authorization.</param>
        /// <returns>A task representing the asynchronous operation and containing the response.</returns>
        public async Task<ResponseCommon<T>> PutAsync<T>(string url, object data, bool useCryptoToken = false)
        {
            try
            {
                _logger.LogInformation($"Sending PUT request to: {_httpClient.BaseAddress}/{url}");
                var content = CreateJsonContent(data);
                AddAuthorizationHeader(useCryptoToken);
                var response = await _httpClient.PutAsync(url, content);
                return await HandleResponse<T>(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error sending PUT request to: {_httpClient.BaseAddress}/{url}");
                return FailedRequest<T>("Failed to send PUT request", 500);
            }
        }

        /// <summary>
        /// Sends a DELETE request.
        /// </summary>
        /// <param name="url">The URL to which the request is sent.</param>
        /// <param name="useCryptoToken">Specifies whether to use a cryptographic token for authorization.</param>
        /// <returns>A task representing the asynchronous operation and indicating whether the request was successful.</returns>
        public async Task<bool> DeleteAsync(string url, bool useCryptoToken = false)
        {
            try
            {
                _logger.LogInformation($"Sending DELETE request to: {_httpClient.BaseAddress}/{url}");
                AddAuthorizationHeader(useCryptoToken);
                var response = await _httpClient.DeleteAsync(url);

                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    _logger.LogInformation($"DELETE request to: {_httpClient.BaseAddress}/{url} successful (No Content)");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error sending DELETE request to: {_httpClient.BaseAddress}/{url}");
                return false;
            }
        }

        private static StringContent CreateJsonContent(object data)
        {
            var json = JsonSerializer.Serialize(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private void AddAuthorizationHeader(bool useCryptoToken)
        {
            if (useCryptoToken)
            {
                var accessToken = AccessTokenManager.Instance.GetAccessToken();
                if (!string.IsNullOrEmpty(accessToken))
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                }
            }
        }

        private async Task<ResponseCommon<T>> HandleResponse<T>(HttpResponseMessage response)
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

        /// <summary>
        /// Creates a failed response object.
        /// </summary>
        /// <typeparam name="T">The type of the response data.</typeparam>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="statusCode">The HTTP status code.</param>
        /// <returns>A failed response object with the specified error message and status code.</returns>
        public static ResponseCommon<T> FailedRequest<T>(string errorMessage, int statusCode)
        {
            return ResponseCommon<T>.Failure("Failed to make request", statusCode, errorMessage);
        }
    }
}
