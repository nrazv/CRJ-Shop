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
        public DbSet<ProductCategory> ProductCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<ProductCategory>()
               .Property(e => e.Category)
               .HasConversion(
                v => v.ToString(),
                v => (Category)Enum.Parse(typeof(Category), v)
           );
        }

    }
}