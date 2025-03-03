using CRJ_Shop.Data;

namespace CRJ_Shop.Models;

public class DummyData
{
    public static void SeedData(AppDbContext database)
    {
        if (!database.Products.Any())
        {
            database.Products.AddRange(new List<Product>
            {
                new Product { Name = "Product-1", Description = "This is a product", Price = 49.99 },
                new Product { Name = "Product-2", Description = "This is a product", Price = 50.00 },
                new Product { Name = "Product-4", Description = "This is a product", Price = 100.00},
                new Product { Name = "Product-5", Description = "This is a product", Price = 100.00},
            });
            database.SaveChanges();
        }
    }
}