using InventoryManagement_2.Entity;
using InventoryManagement_2.Models;
using Microsoft.EntityFrameworkCore;


namespace InventoryManagement_2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Product2>? Units { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Sales>? Sales { get; set; }

        public DbSet<SalesDetails>? SalesDetails { get; set; }

        public DbSet<Units>? Unit { get; set; }
        public DbSet<Stock>? Stock { get; set; }
        public DbSet<Purchase>? Purchases { get; set; }

        public DbSet<PurchaseDetails>? PurchaseDetails { get; set; }

        public DbSet<Supplier>? Suppliers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            

            modelBuilder.Entity<PurchaseDetails>()
                  .HasOne(e => e.Product)
                  .WithMany()
                  .HasForeignKey(e => e.ProductId)
                  .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PurchaseDetails>()
                .HasOne(e => e.Category)
                .WithMany()
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PurchaseDetails>()
                .HasOne(e => e.Unit)
                .WithMany()
                .HasForeignKey(e => e.UnitId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PurchaseDetails>()
                .HasOne(e => e.Purchase)
                .WithMany()
                .HasForeignKey(e => e.PurchaseId)
                .OnDelete(DeleteBehavior.NoAction);



        }


    }
}