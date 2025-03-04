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


    }
}