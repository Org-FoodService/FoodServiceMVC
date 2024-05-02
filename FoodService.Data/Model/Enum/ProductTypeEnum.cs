using System.ComponentModel;

namespace FoodService.Data.Model.Enum
{
    /// <summary>
    /// Enumeration representing the type of a product.
    /// </summary>
    public enum ProductTypeEnum
    {
        /// <summary>
        /// No type specified.
        /// </summary>
        [Description("None")]
        None = 0,

        /// <summary>
        /// Ingredient type.
        /// </summary>
        [Description("Ingredient")]
        Ingredient = 1,

        /// <summary>
        /// Beverage type.
        /// </summary>
        [Description("Beverage")]
        Beverage = 2,

        /// <summary>
        /// Dish type.
        /// </summary>
        [Description("Dish")]
        Dish = 3
    }
}
