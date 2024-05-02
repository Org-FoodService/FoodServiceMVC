using Microsoft.AspNetCore.Mvc;
using FoodService.ViewModel;
using System.Diagnostics;

namespace FoodService.Controllers
{
    /// <summary>
    /// Controller for handling home-related actions.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Displays the home page.
        /// </summary>
        /// <returns>The home view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Handles errors and displays the error page.
        /// </summary>
        /// <returns>The error view with error details.</returns>
        public IActionResult Error()
        {
            // Gets the error request ID from the HttpContext
            var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            // Sets up the model for your error view
            var errorViewModel = new ErrorViewModel
            {
                RequestId = requestId
            };

            // Returns the error view with the model
            return View(errorViewModel);
        }
    }
}
