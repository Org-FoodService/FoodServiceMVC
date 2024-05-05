using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FoodService.Config
{
    /// <summary>
    /// Custom exception filter attribute to handle exceptions globally.
    /// </summary>
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Called when an exception occurs in the application.
        /// </summary>
        /// <param name="context">The exception context containing information about the exception.</param>
        public override void OnException(ExceptionContext context)
        {
            // Redirects to the error page
            context.Result = new RedirectToActionResult("Error", "Home", null);
            context.ExceptionHandled = true;
        }
    }
}
