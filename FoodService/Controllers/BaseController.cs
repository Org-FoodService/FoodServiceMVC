using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using FoodService.Config;

namespace FoodService.Controllers
{
    /// <summary>
    /// Base controller for common functionality and dependencies.
    /// </summary>
    public class BaseController : Controller
    {
        protected readonly ILogger<BaseController> _logger;
        protected readonly LanguageService _localization;

        /// <summary>
        /// Gets the current culture.
        /// </summary>
        public string CurrentCulture => CultureInfo.CurrentCulture.Name;

        /// <summary>
        /// Constructor for BaseController.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="localization">The localization service.</param>
        public BaseController(ILogger<BaseController> logger, LanguageService localization)
        {
            _logger = logger;
            _localization = localization;
        }
    }
}
