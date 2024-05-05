namespace FoodService.Config.Globalization
{
    /// <summary>
    /// Constraint to validate the culture route parameter.
    /// </summary>
    public class CultureRouteConstraint : IRouteConstraint
    {
        /// <summary>
        /// Determines whether the route constraint matches the specified route data.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="route">The router.</param>
        /// <param name="routeKey">The route key.</param>
        /// <param name="values">The route values.</param>
        /// <param name="routeDirection">The route direction.</param>
        /// <returns><c>true</c> if the route constraint matches the specified route data; otherwise, <c>false</c>.</returns>
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.ContainsKey("culture"))
                return false;

            string culture = values["culture"]?.ToString();
            return IsCultureSupported(culture);
        }

        /// <summary>
        /// Determines whether the specified culture is supported.
        /// </summary>
        /// <param name="culture">The culture to check.</param>
        /// <returns><c>true</c> if the culture is supported; otherwise, <c>false</c>.</returns>
        private bool IsCultureSupported(string culture)
        {
            // Add your logic here to check if the language is supported in your application
            // For example, check if it's in the list of supported languages
            return culture switch
            {
                "en" => true,
                "pt-BR" => true,
                _ => false,
            };
        }
    }
}
