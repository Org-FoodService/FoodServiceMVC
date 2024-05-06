using FoodService.HttpRequest.Interface;
using FoodService.Nugget.Models;

namespace FoodService.HttpRequest
{
    public class ProductHttpRequest : IProductHttpRequest
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly ILogger<ProductHttpRequest> _logger;

        public ProductHttpRequest(string baseUrl, ILogger<ProductHttpRequest> logger)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl.TrimEnd('/');
            _logger = logger;
        }

        public async Task<Product[]> GetAllProducts()
        {
            _logger.LogInformation("Fetching all products");
            var response = await _httpClient.GetFromJsonAsync<Product[]>(_baseUrl + "/api/Product");
            if (response == null)
            {
                _logger.LogError("Failed to fetch products.");
                throw new Exception("Failed to fetch products.");
            }

            return response;
        }

        public async Task<ResponseCommon<Product>> GetProductById(int id)
        {
            _logger.LogInformation($"Fetching product with ID: {id}");
            var response = await _httpClient.GetFromJsonAsync<ResponseCommon<Product>>(_baseUrl + $"/api/Product/{id}");
            if (response == null)
            {
                _logger.LogError($"Failed to fetch product with ID: {id}.");
                throw new Exception($"Failed to fetch product with ID: {id}.");
            }

            return response;
        }

        public async Task<ResponseCommon<Product>> CreateProduct(Product product)
        {
            _logger.LogInformation("Creating a new product");
            var response = await _httpClient.PostAsJsonAsync(_baseUrl + "/api/Product", product);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ResponseCommon<Product>>();
        }

        public async Task<ResponseCommon<Product>> UpdateProduct(int id, Product product)
        {
            _logger.LogInformation($"Updating product with ID: {id}");
            var response = await _httpClient.PutAsJsonAsync(_baseUrl + $"/api/Product/{id}", product);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ResponseCommon<Product>>();
        }

        public async Task DeleteProduct(int id)
        {
            _logger.LogInformation($"Deleting product with ID: {id}");
            var response = await _httpClient.DeleteAsync(_baseUrl + $"/api/Product/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
