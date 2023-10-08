using InventoryManagement_2.Entity;
using InventoryManagement_2.Models;
using Microsoft.EntityFrameworkCore;


namespace InventoryManagement_2.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       public DbSet<Users> Users{get;set;} 
       public DbSet<Product2>? Units { get; set; }
        public DbSet<Category>? Categories { get; set; }

       public DbSet<Sales>? Sales { get; set; }

        public DbSet<SalesDetails>? SalesDetails { get; set; }
    }
}