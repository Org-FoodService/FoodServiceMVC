using FoodService.Data.Model.Auth.User;
using FoodService.Interface.Repository.Generic;

namespace FoodService.Core.Interface.Repository
{
    /// <summary>
    /// Interface for the repository of users.
    /// </summary>
    public interface IUserRepository : IGenericRepository<ApplicationUser, int>
    {
    }
}
