using FoodService.Config.Globalization;
using FoodService.Core.Interface.Command;
using FoodService.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FoodService.Controllers
{
    /// <summary>
    /// Controller for managing product-related actions.
    /// </summary>
    public class ProductController : BaseController
    {
        private readonly IProductCommand _ProductCommand;

        /// <summary>
        /// Constructor for ProductController.
        /// </summary>
        /// <param name="ProductCommand">The product command service.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="localization">The localization service.</param>
        public ProductController(
            IProductCommand ProductCommand,
            ILogger<ProductController> logger,
            LanguageService localization) : base(logger, localization)
        {
            _ProductCommand = ProductCommand;
        }

        /// <summary>
        /// Displays a list of products.
        /// </summary>
        /// <returns>The product list view.</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Logs the attempt to retrieve all products
            _logger.LogInformation("Attempting to retrieve all products.");

            var response = await _ProductCommand.GetAllProducts();

            // Checks if the status code is in the 200 range
            if (response.StatusCode < 200 || response.StatusCode >= 300)
            {
                // Logs the error status code
                _logger.LogError("Error retrieving products. Status code: {StatusCode}", response.StatusCode);

                // If it's out of range, redirects to an error page
                return RedirectToAction("Error", "Home");
            }
            else // If it's in range, passes the data to the view
            {
                // Logs successful retrieval of products
                _logger.LogInformation("Products retrieved successfully.");

                var viewModel = new List<ProductViewModel>();
                foreach (var item in response.Data)
                {
                    viewModel.Add(new ProductViewModel(item));
                }
                return View(viewModel);
            }
        }

        /// <summary>
        /// Throws an exception to simulate an error.
        /// </summary>
        /// <returns>An error message.</returns>
        public IActionResult SimulateError()
        {
            // Logs the simulation of an error
            _logger.LogWarning("Simulation of an error.");

            throw new Exception("This is just a simulation error!");
        }
    }
}
