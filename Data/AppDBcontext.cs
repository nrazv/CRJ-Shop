using CRJ_Shop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CRJ_Shop.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
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
            base.OnModelCreating(modelBuilder);


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


            string adminRoleId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();
            string adminUserId = Guid.NewGuid().ToString();

            // Seed roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = userRoleId, Name = "User", NormalizedName = "USER" }
            );

            // create an admin user with the password "password"
            var hasher = new PasswordHasher<IdentityUser>();
            var adminUser = new IdentityUser
            {
                Id = adminUserId,
                UserName = "admin@test.com",
                Email = "admin@test.com",
                PasswordHash = hasher.HashPassword(null, "Password123!")
            };

            // inserts the admin user
            modelBuilder.Entity<IdentityUser>().HasData(adminUser);

            // assign the admin role to the admin user
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = adminUserId, RoleId = adminRoleId }
            );


        }

    }
}