﻿using FoodService.HttpRequest;
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
            services.AddScoped<IProductHttpRequest, ProductHttpRequest>(provider =>
            {


                var logger = provider.GetRequiredService<ILogger<ProductHttpRequest>>();
                var baseUrl = "https://your-api-base-url.com"; // Update with your actual base URL

                // Instantiate ProductHttpRequest with the base URL and logger
                return new ProductHttpRequest(baseUrl, logger);
            });
            services.AddScoped<IAuthHttpRequest, AuthHttpRequest>();
        }
    }
}
