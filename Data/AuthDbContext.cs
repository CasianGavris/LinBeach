using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LinBeach.Data
{
    public class AuthDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            
            var sAdminId = "876a7a88-8837-4aac-a827-fba899ec4ca5";
            var AdminId = "7cb38325-9b5b-4f6b-b27e-60c4143e9b4d";
            var UserId = "fda10325-de6d-4695-8642-821c5c5302e1";

            var roles = new List<IdentityRole>
            {
                new IdentityRole { Name = "SAdmin", NormalizedName = "SAdmin", Id = sAdminId, ConcurrencyStamp = sAdminId },
                new IdentityRole { Name = "Admin", NormalizedName = "Admin", Id = AdminId, ConcurrencyStamp = AdminId },
                new IdentityRole { Name = "User", NormalizedName = "User", Id = UserId, ConcurrencyStamp = UserId },
            };

            builder.Entity<IdentityRole>().HasData(roles);

            var SAdminId = "536727b7-9218-4d43-933f-7d5dc7a9cf82";
            var sAdminUser = new ApplicationUser()
            {
                Id = SAdminId,
                UserName = "SuperAdmin",
                NormalizedUserName = "SuperAdmin".ToUpper(),
                Email = "superadmin@linbeach.ro",
                NormalizedEmail = "superadmin@linbeach.ro".ToUpper(),
                FullName = "superadmin",  
                Birthdate = new DateTime(2000, 1, 2)  
            };

            sAdminUser.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(sAdminUser, "LinBeach68@");
            builder.Entity<ApplicationUser>().HasData(sAdminUser);

            var sAdminRoles = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string> { RoleId = sAdminId, UserId = SAdminId },
                new IdentityUserRole<string> { RoleId = AdminId, UserId = SAdminId },
                new IdentityUserRole<string> { RoleId = UserId, UserId = SAdminId },
            };

            builder.Entity<IdentityUserRole<string>>().HasData(sAdminRoles);
        }
    }
}
