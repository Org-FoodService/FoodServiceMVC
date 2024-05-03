using FoodService.Core.Util;
using FoodService.Data.Model;

namespace FoodService.ViewModel
{
    /// <summary>
    /// Represents the view model for displaying product information.
    /// </summary>
    public class ProductViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductViewModel"/> class.
        /// </summary>
        /// <param name="product">The product entity.</param>
        public ProductViewModel(Product product)
        {
            Description = product.Description?.ToString() ?? "";
            Name = product.Name;
            Price = CurrencyUtils.FormatCurrency(product.Price);
            Type = product.Type.GetEnumDescription() ?? "";
        }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the product.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Gets or sets the type of the product.
        /// </summary>
        public string Type { get; set; }
    }
}
