using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace FoodService.Config.Globalization
{
    public static class GlobalizationConfig
    {
        public static void ConfigureGlobalization(this IServiceCollection services)
        {
            services.AddSingleton<LanguageService>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc().AddViewLocalization().AddDataAnnotationsLocalization(options => {
                options.DataAnnotationLocalizerProvider = (type, factory) => {
                    var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
                    return factory.Create("ShareResource", assemblyName.Name);
                };
            });
            services.Configure<RequestLocalizationOptions>(options => {
                var supportedCultures = new List<CultureInfo> {
                    new CultureInfo("pt-BR"),
                    new CultureInfo("en")
                };
                options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
            });

        }

        public static void ConfigureGlobalization(this WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                var pathSegments = context.Request.Path.Value.Split('/');
                if (pathSegments.Length > 1)
                {
                    var culture = pathSegments[1];
                    var supportedCultures = new[] { "en", "pt-BR" };

                    if (supportedCultures.Contains(culture))
                    {
                        CultureInfo.CurrentCulture = new CultureInfo(culture);
                        CultureInfo.CurrentUICulture = new CultureInfo(culture);
                    }
                }

                await next();
            });
            app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
        }
    }

    /// <summary>
    /// Dummy class to group shared resources
    /// </summary>
    public class SharedResource { }
    public class LanguageService
    {
        private readonly IStringLocalizer _localizer;
        public LanguageService(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("SharedResource", assemblyName.Name); // §REVIEW_DJE: "SharedResource" or "ShareResource"
        }
        public LocalizedString Getkey(string key)
        {
            return _localizer[key];
        }
    }
}

