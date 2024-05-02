using FoodService.Data.Model;
using FoodService.Data.Model.Auth.Role;
using FoodService.Data.Model.Auth.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodService.Data.Context
{
    /// <summary>
    /// Database context for the application, derived from IdentityDbContext.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="AppDbContext"/> class.
    /// </remarks>
    /// <param name="options">The options for this context.</param>
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<UserBase, ApplicationRole, int>(options)
    {

        /// <summary>
        /// Represents the users in the database.
        /// </summary>
        public DbSet<ApplicationUser> User { get; set; }

        /// <summary>
        /// Represents the roles in the database.
        /// </summary>
        public DbSet<ApplicationRole> Role { get; set; }

        /// <summary>
        /// Represents the products in the database.
        /// </summary>
        public DbSet<Product> Product { get; set; }

        /// <summary>
        /// Represents the ingredients in the database.
        /// </summary>
        public DbSet<Ingredient> Ingredient { get; set; }

        /// <summary>
        /// Represents the order items in the database.
        /// </summary>
        public DbSet<OrderItem> OrderItem { get; set; }

        /// <summary>
        /// Represents the orders in the database.
        /// </summary>
        public DbSet<Order> Order { get; set; }
    }
}
