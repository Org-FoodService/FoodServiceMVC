namespace FoodService.Data.Model.Abstract
{
    /// <summary>
    /// Abstract class representing an item.
    /// </summary>
    public abstract class Item
    {
        /// <summary>
        /// Gets or sets the ID of the item.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the item.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the quantity in stock of the item.
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        /// Gets or sets the image URL of the item.
        /// </summary>
        public byte[]? Image { get; set; }
    }
}
