using System.ComponentModel.DataAnnotations.Schema;

namespace FoodService.Data.Model
{
    /// <summary>
    /// Represents a many-to-many relationship between Product and Ingredient.
    /// </summary>
    public class ProductIngredient
    {
        /// <summary>
        /// Gets or sets the ID of the Product.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product associated with this product-ingredient relationship.
        /// </summary>
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the ID of the Ingredient.
        /// </summary>
        public int IngredientId { get; set; }

        /// <summary>
        /// Gets or sets the ingredient associated with this product-ingredient relationship.
        /// </summary>
        [ForeignKey("IngredientId")]
        public Ingredient Ingredient { get; set; }
    }
}
