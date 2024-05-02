using FoodService.Data.Model.Abstract;
using System;

namespace FoodService.Data.Model
{
    /// <summary>
    /// Represents an ingredient in the application.
    /// </summary>
    public class Ingredient : Item
    {
        /// <summary>
        /// Gets or sets a value indicating whether the ingredient is fresh.
        /// </summary>
        public bool IsFresh { get; set; }

        /// <summary>
        /// Gets or sets the expiration date of the ingredient.
        /// </summary>
        public DateTime ExpirationDate { get; set; }
    }
}
