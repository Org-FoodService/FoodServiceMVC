using FoodService.Data.Model.Abstract;
using System.Text.Json.Serialization;

namespace FoodService.Data.Model
{
    /// <summary>
    /// Represents an ingredient in the application.
    /// </summary>
    public class Ingredient : Item
    {
        /// <summary>
        /// Gets or sets the ID of the Ingredient.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the ingredient is fresh.
        /// </summary>
        public bool IsFresh { get; set; }

        /// <summary>
        /// Gets or sets the expiration date of the ingredient.
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the quantity in stock of the item.
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        /// Gets or sets the list of product ingredients associated with this ingredient.
        /// </summary>
        [JsonIgnore()]
        public List<ProductIngredient>? ProductIngredients { get; set; }

    }
}
