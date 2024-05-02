using FoodService.Data.Model;
using FoodService.Interface.Repository.Generic;

namespace FoodService.Core.Interface.Repository
{
    /// <summary>
    /// Interface for the repository of products.
    /// </summary>
    public interface IProductRepository : IGenericRepository<Product, int>
    {
    }
}
