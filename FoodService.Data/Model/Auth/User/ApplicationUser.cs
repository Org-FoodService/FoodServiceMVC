namespace FoodService.Data.Model.Auth.User
{
    /// <summary>
    /// Represents an application user.
    /// </summary>
    public class ApplicationUser : UserBase
    {
        /// <summary>
        /// Gets or sets the CPF or CNPJ of the user.
        /// </summary>
        public required string CpfCnpj { get; set; }
    }
}
