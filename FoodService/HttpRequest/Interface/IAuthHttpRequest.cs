using FoodService.Models.Dto;
using FoodService.Models;
using FoodService.Models.Auth.User;

namespace FoodService.HttpRequest.Interface
{
    public interface IAuthHttpRequest
    {
        Task<ResponseCommon<bool>> AddUserToAdminRole(int userId);
        Task<ResponseCommon<UserBase>> GetCurrentUser();
        Task<ResponseCommon<UserDto>> GetUserDto(int id);
        Task<ResponseCommon<List<ClientUser>>> ListUsers();
        Task<ResponseCommon<bool>> SignIn(SignInDto signInDto);
        Task<ResponseCommon<bool>> SignUp(SignUpDto signUpDto);
    }
}