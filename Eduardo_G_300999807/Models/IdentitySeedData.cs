using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Eduardo_G_300999807.Models
{  
        public static class IdentitySeedData
        {
            private const string adminUser = "Admin";
            private const string adminPassword = "Abc123$";
            private const string generalUser = "User";
            private const string generalUserPassword = "Abc123$";
            public static async void EnsurePopulated(IApplicationBuilder app)
            {
                UserManager<IdentityUser> userManager = app.ApplicationServices
                .GetRequiredService<UserManager<IdentityUser>>();
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
        }
        }
    }

