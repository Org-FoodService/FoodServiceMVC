using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection;

namespace FoodService.Config
{
    /// <summary>
    /// Configuration class for globalization settings.
    /// </summary>
    public static class GlobalizationConfig
    {
        /// <summary>
        /// Configures globalization settings for the application.
        /// </summary>
        /// <param name="services">The collection of services.</param>
        public static void ConfigureGlobalization(this IServiceCollection services)
        {
            // Adds the language service
            services.AddSingleton<LanguageService>();

            // Configures localization options
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            // Configures MVC for view localization and data annotations localization
            services.AddMvc().AddViewLocalization().AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                {
                    var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName!);
                    return factory.Create("SharedResource", assemblyName.Name!);
                };
            });

            // Configures request localization options
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("pt-BR"),
                    new CultureInfo("en")
                };
                options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
            });

            // Configure EnumExtensions with IStringLocalizerFactory
            var serviceProvider = services.BuildServiceProvider();
            var localizerFactory = serviceProvider.GetService<IStringLocalizerFactory>();
            EnumExtensions.SetLocalizerFactory(localizerFactory!);
        }

        /// <summary>
        /// Configures globalization settings for the web application.
        /// </summary>
        /// <param name="app">The web application.</param>
        public static void ConfigureGlobalization(this WebApplication app)
        {
            // Configures request localization middleware
            app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
        }
    }

    /// <summary>
    /// Dummy class to group shared resources.
    /// </summary>
    public class SharedResource { }

    /// <summary>
    /// Service for managing language resources.
    /// </summary>
    public class LanguageService
    {
        private readonly IStringLocalizer _localizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageService"/> class.
        /// </summary>
        /// <param name="factory">The string localizer factory.</param>
        public LanguageService(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName!);
            _localizer = factory.Create("SharedResource", assemblyName.Name!);
        }

        /// <summary>
        /// Gets the localized string for the specified key.
        /// </summary>
        /// <param name="key">The key of the localized string.</param>
        /// <returns>The localized string.</returns>
        public LocalizedString Getkey(string key)
        {
            return _localizer[key];
        }
    }
}
