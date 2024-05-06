using FoodService.HttpRequest.Interface;
using FoodService.Nuget.Models;

namespace FoodService.HttpRequest
{
    /// <summary>
    /// Class responsible for making HTTP requests related to products.
    /// </summary>
    public class ProductHttpRequest : IProductHttpRequest
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly ILogger<ProductHttpRequest> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductHttpRequest"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL of the API.</param>
        /// <param name="logger">The logger.</param>
        public ProductHttpRequest(string baseUrl, ILogger<ProductHttpRequest> logger)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl.TrimEnd('/');
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all products from the API.
        /// </summary>
        /// <returns>A response containing an array of products.</returns>
        public async Task<ResponseCommon<Product[]>> GetAllProducts()
        {
            _logger.LogInformation("Fetching all products");
            var response = await _httpClient.GetFromJsonAsync<ResponseCommon<Product[]>>(_baseUrl + "/api/Product");
            if (response == null)
            {
                _logger.LogError("Failed to fetch products.");
                throw new Exception("Failed to fetch products.");
            }

            return response;
        }

        /// <summary>
        /// Retrieves a product by its ID from the API.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        /// <returns>A response containing the product.</returns>
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

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="product">The product to create.</param>
        /// <returns>A response containing the created product.</returns>
        public async Task<ResponseCommon<Product>> CreateProduct(Product product)
        {
            _logger.LogInformation("Creating a new product");
            var response = await _httpClient.PostAsJsonAsync(_baseUrl + "/api/Product", product);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ResponseCommon<Product>>();
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="id">The ID of the product to update.</param>
        /// <param name="product">The updated product data.</param>
        /// <returns>A response containing the updated product.</returns>
        public async Task<ResponseCommon<Product>> UpdateProduct(int id, Product product)
        {
            _logger.LogInformation($"Updating product with ID: {id}");
            var response = await _httpClient.PutAsJsonAsync(_baseUrl + $"/api/Product/{id}", product);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ResponseCommon<Product>>();
        }

        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteProduct(int id)
        {
            _logger.LogInformation($"Deleting product with ID: {id}");
            var response = await _httpClient.DeleteAsync(_baseUrl + $"/api/Product/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
