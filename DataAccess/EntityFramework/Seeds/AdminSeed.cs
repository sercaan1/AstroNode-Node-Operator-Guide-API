using Core.Enums;
using DataAccess.EntityFramework.Abstracts;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework.Seeds
{
    public class AdminSeed
    {
        public static async Task SeedAsync(UserManager<IdentityUser> userManager, IAdminRepository adminRepository)
        {
            var adminUser = new IdentityUser()
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                EmailConfirmed = true
            };

            if (!userManager.Users.Any(a => a.UserName == "admin@admin.com"))
            {
                await userManager.CreateAsync(adminUser, "Password1.");
                await userManager.AddToRoleAsync(adminUser, Roles.Admin.ToString());
            }

            if (!await adminRepository.AnyAsync())
            {
                var admin = new Admin()
                {
                    FirstName = "Alperen",
                    LastName = "Etlik",
                    Email = adminUser.Email,
                    IdentityId = adminUser.Id
                };

                await adminRepository.AddAsync(admin);
            }
        }
    }
}
