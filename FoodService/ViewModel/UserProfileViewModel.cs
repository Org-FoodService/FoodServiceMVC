using FoodService.Models.Auth.User;

namespace FoodService.ViewModel
{
    public class UserProfileViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public UserProfileViewModel(UserBase user)
        {
            Name = user.UserName!;
            Email = user.Email!;
        }
    }
}
