using Microsoft.AspNetCore.Mvc;
using FoodService.ViewModel;
using System.Diagnostics;
using FoodService.Config;
using FoodService.HttpRequest.Interface;

namespace FoodService.Controllers
{
    /// <summary>
    /// Controller for handling user-related actions.
    /// </summary>
    public class UserController : BaseController
    {
        /// <summary>
        /// The HTTP request service.
        /// </summary>
        private readonly IAuthHttpRequest _httpRequest;

        /// <summary>
        /// Constructor for UserController.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="localization">The localization service.</param>
        public UserController(ILogger<UserController> logger, LanguageService localization, IAuthHttpRequest httpRequest)
            : base(logger, localization)
        {
            _httpRequest = httpRequest;
        }

        /// <summary>
        /// Displays the user profile page.
        /// </summary>
        /// <returns>The user profile view.</returns>
        public async Task<IActionResult> Profile()
        {
            var response = await _httpRequest.GetCurrentUser();
            if (response == null || !response.IsSuccess)
            {
                _logger.LogInformation("User profile page accessed. User is not authenticated.");
                return RedirectToAction("SignIn", "Auth");
            }
            var viewModel = new UserProfileViewModel(response.Data);
            _logger.LogInformation("User profile page accessed. User is authenticated.");
            return View("Profile", viewModel);
        }

        /// <summary>
        /// Handles errors and displays the error page.
        /// </summary>
        /// <returns>The error view with error details.</returns>
        public IActionResult Error()
        {
            // Gets the error request ID from the HttpContext
            var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            // Logs the error request ID
            _logger.LogError("Error occurred. Request ID: {RequestId}", requestId);

            // Sets up the model for the error view
            var errorViewModel = new ErrorViewModel
            {
                RequestId = requestId
            };

            // Returns the error view with the model
            return View(errorViewModel);
        }
    }
}
