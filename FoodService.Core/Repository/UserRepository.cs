using FoodService.Data.Context;
using FoodService.Core.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using FoodService.Core.Interface.Repository;
using FoodService.Data.Model.Auth.User;

namespace FoodService.Core.Repository
{
    /// <summary>
    /// Repository implementation for user entities.
    /// </summary>
    public class UserRepository : GenericRepository<ApplicationUser, int>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the UserRepository class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
