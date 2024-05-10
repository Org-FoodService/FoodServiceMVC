using System;
using System.Globalization;
using System.Reflection;
using System.ComponentModel;
using Microsoft.Extensions.Localization;
using FoodService.Config;

public static class EnumExtensions
{
    private static IStringLocalizerFactory? _localizerFactory;

    public static void SetLocalizerFactory(IStringLocalizerFactory localizerFactory)
    {
        _localizerFactory = localizerFactory;
    }

    /// <summary>
    /// Gets the description of an enum value.
    /// </summary>
    /// <param name="value">The enum value.</param>
    /// <param name="culture">The culture for which to get the description.</param>
    /// <returns>The description of the enum value, or null if not found.</returns>
    public static string? GetEnumDescription(this Enum value, CultureInfo culture)
    {
        FieldInfo? field = value.GetType().GetField(value.ToString());

        // If the field is not found, return null
        if (field == null) return null;

        // Get the DescriptionAttribute associated with the enum value
        DescriptionAttribute? attribute = (DescriptionAttribute?)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

        // If DescriptionAttribute is not found, return the enum value's string representation
        if (attribute == null) return value.ToString();

        // If culture is null, return the default description
        if (culture == null) return attribute.Description;

        // Try to get the localized description using the specified culture
        if (_localizerFactory != null)
        {
            var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName!);
            var localizer = _localizerFactory.Create("SharedResource", assemblyName.Name);
            var localizedString = localizer[value.ToString()];
            return localizedString;
        }

        // If no localizer factory is available, return the default description
        return attribute.Description;
    }
}
