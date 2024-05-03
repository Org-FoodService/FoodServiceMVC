using Microsoft.AspNetCore.Mvc;
using FoodService.ViewModel;
using System.Diagnostics;
using Microsoft.AspNetCore.Localization;
using FoodService.Config.Globalization;

namespace FoodService.Controllers
{
    /// <summary>
    /// Controller for handling home-related actions.
    /// </summary>
    public class HomeController : BaseController
    {
        /// <summary>
        /// Constructor for HomeController.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="localization">The localization service.</param>
        public HomeController(ILogger<HomeController> logger, LanguageService localization)
            : base(logger, localization)
        {
        }

        /// <summary>
        /// Changes the application's current culture.
        /// </summary>
        /// <param name="culture">The culture to change to.</param>
        /// <returns>Redirects to the previous page.</returns>
        public IActionResult ChangeLanguage(string culture)
        {
            // Sets the culture cookie for language preference
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            });

            // Logs the culture change
            _logger.LogInformation("Language changed to: {Culture}", culture);

            // Redirects to the previous page
            return Redirect(Request.Headers["Referer"].ToString());
        }


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
