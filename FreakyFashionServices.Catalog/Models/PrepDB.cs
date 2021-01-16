using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FreakyFashionServices.Catalog.Models.Data;

namespace FreakyFashionServices.Catalog.Models
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<FreakyFashionContext>());
            }
        }

        public static void SeedData(FreakyFashionContext context)
        {
            System.Console.WriteLine("Applying Migrations .....");
            context.Database.Migrate();
            if(!context.Items.Any())
            {
                System.Console.WriteLine("Adding data - seeding....");
                context.Items.AddRange(
                    new Items()
                        {
                            Name="Black T-SHirt",
                            Description="Lorem ipsum dolor",
                            Price="299",
                            AvailableStock=12
                        },
                        new Items()
                        {
                            Name = "Turtle Neck-sweater",
                            Description = "Lorem ipsum dolor",
                            Price = "199",
                            AvailableStock = 5
                        },
                        new Items()
                        {
                            Name = "Red Hoodie",
                            Description = "Lorem ipsum dolor",
                            Price = "399",
                            AvailableStock = 17
                        }
                    );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Already have data - not seeding");
            }
        }
    }
}
