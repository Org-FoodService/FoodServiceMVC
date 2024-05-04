using Microsoft.AspNetCore.Identity;

namespace FoodService.Data.Model.Auth.Role
{
    /// <summary>
    /// Represents an application role.
    /// </summary>
    public class ApplicationRole : IdentityRole<int>
    {
        public bool CanControlStock { get; set; }
        public bool CanChangePrice { get; set; }
        public bool CanAddEmployee { get; set; }
        public bool CanAddProduct { get; set; }
        public bool CanAccessFinancialResources { get; set; }
    }
}
