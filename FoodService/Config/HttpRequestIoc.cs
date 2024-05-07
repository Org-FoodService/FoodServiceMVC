using FoodService.HttpRequest;
using FoodService.HttpRequest.Interface;

namespace FoodService.Config
{
    /// <summary>
    /// IoC configuration class for command services.
    /// </summary>
    public static class HttpRequestIoc
    {
        /// <summary>
        /// Configures IoC container for command services.
        /// </summary>
        /// <param name="services">The service collection.</param>
        public static void ConfigureHttpRequestIoc(this IServiceCollection services, WebApplicationBuilder builder)
        {
            string baseUrlApi = builder.Configuration["BASE_URL_API"]!;
            string pathToApi = "/api";

            services.AddScoped<IAuthHttpRequest, AuthHttpRequest>(provider =>
            {
                var logger = provider.GetRequiredService<ILogger<AuthHttpRequest>>();
                var baseUrl = baseUrlApi + pathToApi + "auth";

                // Instantiate AuthHttpRequest with the base URL and logger
                return new AuthHttpRequest(baseUrl, logger);
            });

            services.AddScoped<IProductHttpRequest, ProductHttpRequest>(provider =>
            {
                var logger = provider.GetRequiredService<ILogger<ProductHttpRequest>>();
                var baseUrl = baseUrlApi + pathToApi + "product";

                // Instantiate ProductHttpRequest with the base URL and logger
                return new ProductHttpRequest(baseUrl, logger);
            });
        }
    }
}
