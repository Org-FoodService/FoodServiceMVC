using FoodService.Config;
using FoodService.HttpRequest.Interface;
using FoodService.Models.Entities;
using FoodService.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FoodService.Controllers
{
    /// <summary>
    /// Controller for handling site settings related requests.
    /// </summary>
    public class SiteSettingsController : BaseController
    {
        private readonly ISiteSettingsHttpRequest _httpRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteSettingsController"/> class.
        /// </summary>
        /// <param name="httpRequest">The HTTP request service for site settings.</param>
        /// <param name="logger">The logger instance.</param>
        /// <param name="localization">The localization service.</param>
        public SiteSettingsController(
            ISiteSettingsHttpRequest httpRequest,
            ILogger<SiteSettingsController> logger,
            LanguageService localization
        ) : base(logger, localization)
        {
            _httpRequest = httpRequest;
        }

        /// <summary>
        /// Displays the index page.
        /// </summary>
        /// <returns>The index view.</returns>
        public IActionResult Index()
        {
            if (UserHasRoleAdmin()) 
                return View();  
            else 
                return View("AccessDenied"); 
        }

        /// <summary>
        /// Displays the index page.
        /// </summary>
        /// <returns>The index view.</returns>
        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }

        /// <summary>
        /// Gets the site settings.
        /// </summary>
        /// <returns>The site settings.</returns>
        [HttpGet]
        public async Task<IActionResult> GetSiteSettings()
        {
            _logger.LogInformation("GetSiteSettings: Request initiated.");

            var response = await _httpRequest.GetSiteSettings();
            var result = CheckResponse(response);

            _logger.LogInformation("GetSiteSettings: Request completed with status code {StatusCode}.", response.StatusCode);

            return result;
        }

        /// <summary>
        /// Saves the site settings.
        /// </summary>
        /// <param name="settings">The site settings to save.</param>
        /// <returns>The result of the save operation.</returns>
        [HttpPost]
        public async Task<IActionResult> SaveSettings([FromBody] SiteSettings settings)
        {
            _logger.LogInformation("SaveSettings: Request initiated.");

            var response = await _httpRequest.UpdateSiteSettings(settings);
            var result = CheckResponse(response);

            return result;
        }

        /// <summary>
        /// Checks the response and returns an appropriate IActionResult.
        /// </summary>
        /// <param name="response">The response to check.</param>
        /// <returns>An IActionResult based on the response.</returns>
        private IActionResult CheckResponse(ResponseCommon<SiteSettings> response)
        {
            if (response.StatusCode < 200 || response.StatusCode >= 300)
            {
                _logger.LogWarning("CheckResponse: Unsuccessful response with status code {StatusCode}. Returning default settings.", response.StatusCode);

                var defaultValue = new SiteSettings
                {
                    Id = 1,
                    PrimaryColor = "#AA2E26",            // Set the primary color
                    SecondaryColor = "#FB9F3A",          // Set the secondary color
                    BackgroundColor = "#f0f0f0",         // Set the background color
                    ServiceName = "FoodService",         // Set the service name
                    DarkColor = "#412D2C",               // Set the dark color
                    TertiaryColor = "#2CAB61",           // Set the tertiary color
                    GreenColor = "#376B4C",              // Set the green color
                    SuccessColor = "#02EB62",            // Set the success color
                    DangerColor = "#8E291F",             // Set the danger color
                };

                return Ok(defaultValue);
            }
            else
            {
                _logger.LogInformation("CheckResponse: Successful response with status code {StatusCode}.", response.StatusCode);

                return Ok(response.Data);
            }
        }
    }
}
