using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FreakyFashionServices.Order.Data;
using FreakyFashionServices.Order.Model.Domains;

namespace FreakyFashionServices.Catalog.Models
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<FreakyFashionOrderContext>());
            }
        }

        public static void SeedData(FreakyFashionOrderContext context)
        {
            System.Console.WriteLine("Applying Migrations .....");
            context.Database.Migrate();
            if(!context.Orders.Any())
            {
                System.Console.WriteLine("Adding data - seeding....");
                context.Orders.AddRange(
                    new Orders()
                    {
                        CustomerIdentifier = "1101",
                        FirstName = "Faisal",
                        LastName = "Haji"
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
