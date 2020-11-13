using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bai29_10.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();
            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Cafe đen",
                        Description = "Cafe đen",
                        Category = "Cafe",
                        Price = 275
                    },
                    new Product
                    {
                        Name = "Cafe sữa đá",
                        Description = "Cafe ngon",
                        Category = "Cafe",
                        Price = 244
                    },
                    new Product
                    {
                        Name = "Cafe nóng",
                        Description = "Cafe ngon",
                        Category = "Cafe",
                        Price = 215
                    },
                    new Product
                    {
                        Name = "Cafe rượu sữa",
                        Description = "Cafe ngon",
                        Category = "Cafe",
                        Price = 2375
                    },
                    new Product
                    {
                        Name = "Sinh tố dưa hấu",
                        Description = "Sinh tố ngon",
                        Category = "Sinh tố",
                        Price = 2375
                    },
                    new Product
                    {
                        Name = "Sinh tố soài",
                        Description = "Sinh tố ngon",
                        Category = "Sinh tố",
                        Price = 2375
                    },
                    new Product
                    {
                        Name = "Sinh chuối",
                        Description = "Sinh tố ngon",
                        Category = "Sinh tố",
                        Price = 2375
                    },
                    new Product
                    {
                        Name = "Trà sữa kiwi",
                        Description = "Trà sữa ngon",
                        Category = "Trà sữa",
                        Price = 2375
                    },
                    new Product
                    {
                        Name = "Trà sữa bạc hà",
                        Description = "Trà sữa ngon",
                        Category = "Trà sữa",
                        Price = 2375
                    },
                    new Product
                    {
                        Name = "Trà sữa chân châu",
                        Description = "Trà sữa ngon",
                        Category = "Trà sữa",
                        Price = 2375
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
