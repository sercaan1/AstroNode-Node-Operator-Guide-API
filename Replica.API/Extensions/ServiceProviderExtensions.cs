using DataAccess.EntityFramework.Abstracts;
using DataAccess.EntityFramework.Seeds;
using Microsoft.AspNetCore.Identity;

namespace Replica.API.Extensions
{
    public static class ServiceProviderExtensions
    {
        public async static Task SeedData(this IServiceProvider service)
        {
            using (var scope = service.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var adminRepository = scope.ServiceProvider.GetRequiredService<IAdminRepository>();

                await RoleSeed.SeedAsync(roleManager);
                await AdminSeed.SeedAsync(userManager, adminRepository);
            }
        }
    }
}
