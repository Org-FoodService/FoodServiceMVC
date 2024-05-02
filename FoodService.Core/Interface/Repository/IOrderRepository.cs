using FoodService.Core.Interface.Repository.Generic;
using FoodService.Data.Model;

namespace FoodService.Core.Interface.Repository
{
    /// <summary>
    /// Interface for the repository of orders.
    /// </summary>
    public interface IOrderRepository : IGenericRepository<Order, int>
    {
    }
}
