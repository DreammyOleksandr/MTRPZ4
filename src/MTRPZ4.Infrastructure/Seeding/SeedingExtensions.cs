using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MTRPZ4.Infrastructure.Seeding
{
    public static class SeedingExtensions
    {
        public static async Task SeedStartupDb(this IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
                var db = dbContext.Database;

                await db.EnsureDeletedAsync();
                await db.EnsureCreatedAsync();

                await SeedData(dbContext);
            }
        }

        private static async Task SeedData(ApplicationDBContext dbContext)
        {
            var colors = ButtonSeeder.GetButtonColors();
            var prices = ButtonSeeder.GetButtonPrices();
            var fonts = ButtonSeeder.GetButtonFonts();

            await dbContext.Colors.AddRangeAsync(colors);
            await dbContext.Prices.AddRangeAsync(prices);
            await dbContext.Fonts.AddRangeAsync(fonts);

            await dbContext.SaveChangesAsync();
        }


    }
}
