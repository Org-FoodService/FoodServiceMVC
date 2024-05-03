namespace FoodService.Data.Model.Abstract
{
    /// <summary>
    /// Abstract class representing an item.
    /// </summary>
    public abstract class Item
    {
        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the item.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the image URL of the item.
        /// </summary>
        public byte[]? Image { get; set; }
    }
}
