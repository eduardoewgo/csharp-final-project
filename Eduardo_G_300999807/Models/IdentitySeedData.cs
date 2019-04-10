using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Eduardo_G_300999807.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Abc123$";
        private const string generalUser = "User";
        private const string generalUserPassword = "Abc123$";
        private const string AdminRole = "Admin";
        private const string GeneralRole = "General";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            UserManager<IdentityUser> userManager = app.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService <RoleManager<IdentityRole>>();

            AppIdentityDbContext context = app.ApplicationServices.GetRequiredService<AppIdentityDbContext>();
            context.Database.Migrate();

            IdentityUser admin = await userManager.FindByIdAsync(adminUser);
            IdentityUser user = await userManager.FindByIdAsync(generalUser);
            if (user == null)
            {
                user = new IdentityUser("User");
                await userManager.CreateAsync(user, generalUserPassword);
            }
               
            if (admin == null)
            {
                admin = new IdentityUser("Admin");
                await userManager.CreateAsync(admin, adminPassword);
            }

            IdentityRole adminRole = await roleManager.FindByNameAsync(AdminRole);
            IdentityRole generalRole = await roleManager.FindByNameAsync(GeneralRole);
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new IdentityRole(AdminRole));
            }
            if (!await userManager.IsInRoleAsync(admin, AdminRole))
            {
                await userManager.AddToRoleAsync(admin, AdminRole);
            }
            if (generalRole == null)
            {
                await roleManager.CreateAsync(new IdentityRole(GeneralRole));
            }
            if (!await userManager.IsInRoleAsync(user, GeneralRole))
            {
                await userManager.AddToRoleAsync(user, GeneralRole);
                await userManager.AddToRoleAsync(admin, GeneralRole);

            }
        }
    }
}