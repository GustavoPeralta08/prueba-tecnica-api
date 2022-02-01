using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wheelzy.Model.Entites;

namespace Wheelzy.Context
{
    public class WheelzyDbContext : DbContext 
    {
        public WheelzyDbContext(DbContextOptions<WheelzyDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().HasData(
            //    new Product
            //    {
            //        ProductId = 1,
            //        Code = "0001",
            //        Description = "Mouse Razer",
            //        Category = "",
            //        SubCategory = "",
            //        Price = 1,
            //        Status = false
            //    }
            //    ); ;
        }
    }
}
