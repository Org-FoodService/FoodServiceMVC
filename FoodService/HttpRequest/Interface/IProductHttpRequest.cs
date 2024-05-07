using FoodService.Models;

namespace FoodService.HttpRequest.Interface
{
    public interface IProductHttpRequest
    {
        Task<ResponseCommon<Product>> CreateProduct(Product product);
        Task DeleteProduct(int id);
        Task<ResponseCommon<Product[]>> GetAllProducts();
        Task<ResponseCommon<Product>> GetProductById(int id);
        Task<ResponseCommon<Product>> UpdateProduct(int id, Product product);
    }
}