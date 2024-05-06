namespace FoodService.Util
{
    /// <summary>
    /// Provides utility methods for currency-related operations.
    /// </summary>
    public static class CurrencyUtils
    {
        /// <summary>
        /// Formats the specified amount into Brazilian currency format (BRL).
        /// </summary>
        /// <param name="amount">The amount to format.</param>
        /// <returns>The formatted currency string.</returns>
        public static string FormatCurrency(decimal amount)
        {
            // Formats the amount into Brazilian currency format
            return $"R${amount:F2}";
        }
    }
}
