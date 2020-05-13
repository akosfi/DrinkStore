using DrinkStore.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace DrinkStore.DAL.Seeder
{
    public class DrinkStoreSeeder
    {
        public static void SeedData(UserManager<User> userManager)
        {
            SeedUsers(userManager);
        }
        private static void SeedUsers(UserManager<User> userManager)
        {
            if (userManager.FindByEmailAsync("admin@admin.com").Result == null)
            {
                User user = new User();
                user.UserName = "admin@admin.com";
                user.Email = "admin@admin.com";
                user.Name = "admin@admin.com";

                IdentityResult result = userManager.CreateAsync(user, "Admin@admin.com1'").Result;

                if (result.Succeeded)
                {
                    IdentityResult claimResult = userManager.AddClaimsAsync(user, new List<Claim> { new Claim("role", "Consumer"), new Claim("role", "Admin") }).Result;
                }
            }


            if (userManager.FindByEmailAsync("consumer@consumer.com").Result == null)
            {
                User user = new User();
                user.UserName = "consumer@consumer.com";
                user.Email = "consumer@consumer.com";
                user.Name = "consumer@consumer.com";

                IdentityResult result = userManager.CreateAsync(user, "Consumer@consumer.com1'").Result;

                if (result.Succeeded)
                {
                    IdentityResult claimResult = userManager.AddClaimsAsync(user, new List<Claim> { new Claim("role", "Consumer")}).Result;
                }
            }
        }
    }
}
