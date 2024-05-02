using FoodService.Core.Interface.Repository.Generic;
using FoodService.Data.Model.Auth.User;

namespace FoodService.Core.Interface.Repository
{
    /// <summary>
    /// Interface for the repository of users.
    /// </summary>
    public interface IUserRepository : IGenericRepository<ClientUser, int>
    {
    }
}
