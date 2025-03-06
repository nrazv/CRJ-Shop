using CRJ_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace CRJ_Shop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<Category>()
               .Property(e => e.ProductCategory)
               .HasConversion(
                v => v.ToString(),
                v => (AvailableCategories)Enum.Parse(typeof(AvailableCategories), v)
           );

            modelBuilder.Entity<ProductCategory>().HasKey(pc => new
            {
                pc.ProductId,
                pc.CategoryId,
            });

            modelBuilder.Entity<ProductCategory>()
             .HasOne(pc => pc.Product)
             .WithMany(p => p.ProductCategories)
             .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId);

        }

    }
}