using FreakyFashionServices.Order.Model.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.Order.Data
{
    public class FreakyFashionOrderContext : DbContext
    {
        public FreakyFashionOrderContext(DbContextOptions<FreakyFashionOrderContext> options) : base(options)
        {

        }

        public DbSet<Orders> Orders { get; set; }
    }
}
