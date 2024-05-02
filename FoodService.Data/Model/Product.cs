using FoodService.Data.Model.Abstract;
using FoodService.Data.Model.Enum;

namespace FoodService.Data.Model
{
    /// <summary>
    /// Represents a product entity.
    /// </summary>
    public class Product : Item
    {
        /// <summary>
        /// Gets or sets a value indicating whether the product is active.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the type of the product.
        /// </summary>
        public ProductTypeEnum Type { get; set; }

        /// <summary>
        /// Gets or sets the brand of the product.
        /// </summary>
        public string? Brand { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        public decimal Price { get; set; }
    }
}
