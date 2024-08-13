﻿using Microsoft.AspNetCore.Identity;
using static BlagoevgradArt.Core.Constants.AdministratorConstants;

namespace BlagoevgradArt.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (userManager != null && roleManager != null && await roleManager.RoleExistsAsync(AdminRole) == false)
            {
                IdentityRole? adminRole = new IdentityRole(AdminRole);
                await roleManager.CreateAsync(adminRole);

                IdentityUser? admin = await userManager.FindByEmailAsync("admin@mail.com");

                if (admin != null)
                {
                    await userManager.AddToRoleAsync(admin, adminRole.Name);
                }
            }
        }
    }
}
