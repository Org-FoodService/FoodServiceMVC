using FoodService.HttpRequest;
using FoodService.HttpRequest.Interface;

namespace FoodService.Config.Ioc
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
        public static void ConfigureHttpRequestIoc(this IServiceCollection services)
        {
            services.AddScoped<IProductHttpRequest, ProductHttpRequest>();
        }
    }
}
