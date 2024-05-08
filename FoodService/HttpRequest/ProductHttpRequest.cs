using FoodService.HttpRequest.Interface;
using FoodService.Models;
using FoodService.Util;

namespace FoodService.HttpRequest
{
    /// <summary>
    /// Class responsible for making HTTP requests related to products.
    /// </summary>
    public class ProductHttpRequest : BaseHttpRequest<ProductHttpRequest>, IProductHttpRequest
    {
        public ProductHttpRequest(string baseUrl, ILogger<ProductHttpRequest> logger) : base(baseUrl, logger)
        {
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
                return await GetAsync<Product[]>("/api/Product");
            }
            catch (Exception ex)
            {
                var errorMessage = "Error occurred while fetching all products.";
                _logger.LogError(ex, errorMessage);
                return HttpUtils.FailedRequest<Product[]>(errorMessage, 500);
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
                return await GetAsync<Product>($"/api/Product/{id}");
            }
            catch (Exception ex)
            {
                var errorMessage = $"Error occurred while fetching product with ID: {id}.";
                _logger.LogError(ex, errorMessage);
                return HttpUtils.FailedRequest<Product>(errorMessage, 500);
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
                return await PostAsync<Product>("/api/Product", product, useCryptoToken: true);
            }
            catch (Exception ex)
            {
                var errorMessage = "Error occurred while creating a new product.";
                _logger.LogError(ex, errorMessage);
                return HttpUtils.FailedRequest<Product>(errorMessage, 500);
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
                return await PutAsync<Product>($"/api/Product/{id}", product, useCryptoToken: true);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Error occurred while updating product with ID: {id}.";
                _logger.LogError(ex, errorMessage);
                return HttpUtils.FailedRequest<Product>(errorMessage, 500);
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
                await DeleteAsync($"/api/Product/{id}", useCryptoToken: true);
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
