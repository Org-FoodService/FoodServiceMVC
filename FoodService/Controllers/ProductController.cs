using FoodService.Core.Interface.Command;
using FoodService.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FoodService.Controllers
{
    /// <summary>
    /// Controller for managing product-related actions.
    /// </summary>
    public class ProductController : Controller
    {
        private readonly IProductCommand _ProductCommand;

        public ProductController(IProductCommand ProductCommand)
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
            var response = await _ProductCommand.GetAllProducts();

            // Checks if the status code is in the 200 range
            if (response.StatusCode < 200 || response.StatusCode >= 300)
            {
                // If it's out of range, redirects to an error page
                return RedirectToAction("Error", "Home");
            }
            else // If it's in range, passes the data to the view
            {
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
            throw new Exception("This is just a simulation error!");
        }
    }
}
