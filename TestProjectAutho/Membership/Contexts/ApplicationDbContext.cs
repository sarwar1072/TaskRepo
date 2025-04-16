using System;
using System.Collections.Generic;
using System.Text;
using Membership.Entities;
using Membership.Seeds;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Membership.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, Guid,
        UserClaim, ApplicationUserRole, UserLogin, RoleClaim, UserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
               .HasData(ApplicationUserSeed.Users);

            builder.Entity<Role>()
                .HasData(RoleSeed.Roles);

            builder.Entity<ApplicationUserRole>()
                .HasData(UserRoleSeed.UserRole);
            base.OnModelCreating(builder);
        }

    }
}
