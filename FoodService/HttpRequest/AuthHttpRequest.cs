using FoodService.Dto;
using FoodService.Nugget.Models.Auth.User;
using FoodService.Nugget.Models;
using System.Text.Json;
using System.Text;
using FoodService.HttpRequest.Interface;

namespace FoodService.HttpRequest
{
    public class AuthHttpRequest : IAuthHttpRequest
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://foodserviceapi20240506113327.azurewebsites.net/api/auth/";

        public AuthHttpRequest()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<ResponseCommon<bool>> SignUp(SignUpDto signUpDto)
        {
            var json = JsonSerializer.Serialize(signUpDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("sign-up", content);
            return await HandleResponse<bool>(response);
        }

        public async Task<ResponseCommon<SsoDto>> SignIn(SignInDto signInDto)
        {
            var json = JsonSerializer.Serialize(signInDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("sign-in", content);
            return await HandleResponse<SsoDto>(response);
        }

        public async Task<ResponseCommon<bool>> AddUserToAdminRole(int userId)
        {
            var response = await _httpClient.PostAsync($"add-user-to-admin-role?userId={userId}", null);
            return await HandleResponse<bool>(response);
        }

        public async Task<ResponseCommon<UserBase>> GetCurrentUser()
        {
            var response = await _httpClient.GetAsync("get-current-user");
            return await HandleResponse<UserBase>(response);
        }

        public async Task<ResponseCommon<UserDto>> GetUserDto(int id)
        {
            var response = await _httpClient.GetAsync($"get-userdto?id={id}");
            return await HandleResponse<UserDto>(response);
        }

        public async Task<ResponseCommon<List<ClientUser>>> ListUsers()
        {
            var response = await _httpClient.GetAsync("list-users");
            return await HandleResponse<List<ClientUser>>(response);
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
                return ResponseCommon<T>.Success(responseObject);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                return ResponseCommon<T>.Failure("Failed to make request", (int)response.StatusCode, errorMessage);
            }
        }
    }
}
