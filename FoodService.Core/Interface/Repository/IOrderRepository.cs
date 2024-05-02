using FoodService.Data.Model;
using FoodService.Interface.Repository.Generic;

namespace FoodService.Interface.Repository
{
    /// <summary>
    /// Interface for the repository of orders.
    /// </summary>
    public interface IOrderRepository : IGenericRepository<Order, int>
    {
    }
}
