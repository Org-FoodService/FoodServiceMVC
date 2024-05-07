using FoodService.HttpRequest.Interface;
using FoodService.Nuget.Models;
using FoodService.Util;
using System.Text.Json;
using System.Text;

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
            _httpClient.BaseAddress = new Uri(_baseUrl);

            _logger = logger;
        }

        /// <summary>
        /// Retrieves all products from the API.
        /// </summary>
        /// <returns>A response containing an array of products.</returns>
        public async Task<ResponseCommon<Product[]>> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("Fetching all products");
                var response = await _httpClient.GetAsync("/api/Product");
                if (response == null)
                {
                    _logger.LogError("Failed to fetch products.");
                    throw new Exception("Failed to fetch products.");
                }

                return await HttpUtils.HandleResponse<Product[]>(response);
            }
            catch (Exception ex)
            {
                var errorMessage = "Error occurred while fetching all products.";
                _logger.LogError(ex, errorMessage);
                return await Task.FromResult(HttpUtils.FailedRequest<Product[]>(errorMessage, 500));
            }
        }

        /// <summary>
        /// Retrieves a product by its ID from the API.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        /// <returns>A response containing the product.</returns>
        public async Task<ResponseCommon<Product>> GetProductById(int id)
        {
            try
            {
                _logger.LogInformation($"Fetching product with ID: {id}");
                var response = await _httpClient.GetAsync($"/api/Product/{id}");
                if (response == null)
                {
                    _logger.LogError($"Failed to fetch product with ID: {id}.");
                    throw new Exception($"Failed to fetch product with ID: {id}.");
                }

                return await HttpUtils.HandleResponse<Product>(response);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Error occurred while fetching product with ID: {id}.";
                _logger.LogError(ex, errorMessage);
                return await Task.FromResult(HttpUtils.FailedRequest<Product>(errorMessage, 500));
            }
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="product">The product to create.</param>
        /// <returns>A response containing the created product.</returns>
        public async Task<ResponseCommon<Product>> CreateProduct(Product product)
        {
            try
            {
                _logger.LogInformation("Creating a new product");
                var json = JsonSerializer.Serialize(product);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/Product", content);
                return await HttpUtils.HandleResponse<Product>(response);
            }
            catch (Exception ex)
            {
                var errorMessage = "Error occurred while creating a new product.";
                _logger.LogError(ex, errorMessage);
                return await Task.FromResult(HttpUtils.FailedRequest<Product>(errorMessage, 500));
            }
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="id">The ID of the product to update.</param>
        /// <param name="product">The updated product data.</param>
        /// <returns>A response containing the updated product.</returns>
        public async Task<ResponseCommon<Product>> UpdateProduct(int id, Product product)
        {
            try
            {
                _logger.LogInformation($"Updating product with ID: {id}");
                var json = JsonSerializer.Serialize(product);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsJsonAsync($"/api/Product/{id}", content);
                response.EnsureSuccessStatusCode();

                return await HttpUtils.HandleResponse<Product>(response);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Error occurred while updating product with ID: {id}.";
                _logger.LogError(ex, errorMessage);
                return await Task.FromResult(HttpUtils.FailedRequest<Product>(errorMessage, 500));
            }
        }

        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteProduct(int id)
        {
            try
            {
                _logger.LogInformation($"Deleting product with ID: {id}");
                var response = await _httpClient.DeleteAsync($"/api/Product/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                var errorMessage = $"Error occurred while deleting product with ID: {id}.";
                _logger.LogError(ex, errorMessage);
                throw new Exception(errorMessage);
            }
        }
    }
}
