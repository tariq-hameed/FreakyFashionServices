using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.Catalog.Models.Data
{
    public class FreakyFashionContext : DbContext
    {
        public FreakyFashionContext(DbContextOptions<FreakyFashionContext> options) : base(options)
        {

        }

        public DbSet<Items> Items { get; set; }
    }
}
