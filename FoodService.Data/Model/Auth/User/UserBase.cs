using Microsoft.AspNetCore.Identity;

namespace FoodService.Data.Model.Auth.User
{
    /// <summary>
    /// Represents a base user in the application.
    /// </summary>
    public class UserBase : IdentityUser<int>
    {
        /// <summary>
        /// Gets or sets the CPF or CNPJ of the user.
        /// </summary>
        public required string CpfCnpj { get; set; }

        /// <summary>
        /// Gets or sets the discriminator of the user.
        /// </summary>
        public string? Discriminator { get; set; }
    }
}
