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

            services.AddScoped<IAuthHttpRequest, AuthHttpRequest>(provider =>
            {
                var logger = provider.GetRequiredService<ILogger<AuthHttpRequest>>();

                // Instantiate AuthHttpRequest with the base URL and logger
                return new AuthHttpRequest(baseUrlApi, logger);
            });

            services.AddScoped<IProductHttpRequest, ProductHttpRequest>(provider =>
            {
                var logger = provider.GetRequiredService<ILogger<ProductHttpRequest>>();

                // Instantiate ProductHttpRequest with the base URL and logger
                return new ProductHttpRequest(baseUrlApi, logger);
            });

            services.AddScoped<ISiteSettingsHttpRequest, SiteSettingsHttpRequest>(provider =>
            {
                var logger = provider.GetRequiredService<ILogger<SiteSettingsHttpRequest>>();

                // Instantiate SiteSettingsHttpRequest with the base URL and logger
                return new SiteSettingsHttpRequest(baseUrlApi, logger);
            });
        }
    }
}
