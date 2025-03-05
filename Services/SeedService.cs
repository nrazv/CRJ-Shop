using CRJ_Shop.Data;
using CRJ_Shop.Models;
using CRJ_Shop.Models.SeedModels;
using CRJ_Shop.Utilities;
using Microsoft.EntityFrameworkCore;

namespace CRJ_Shop.Services;

public class SeedService
{
    private readonly string API_URL = "https://api.escuelajs.co/api/v1/products";
    private HttpClient client;
    private readonly AppDbContext _dbContext;

    public SeedService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        client = new HttpClient();
    }

    public async Task SeedData()
    {
        try
        {

            List<SeedProduct>? seedProducts = await client.GetFromJsonAsync<List<SeedProduct>>(API_URL);
            foreach (var seedProduct in seedProducts)
            {
                Product product = ProductMapper.mapSeedToProduct(seedProduct);
                var category = ProductMapper.GetCategory(seedProduct.category.name);
                var productCategory = _dbContext.ProductCategories.Where(p => p.Category == category);
                await addIfNotExists(product);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task addIfNotExists(Product product)
    {

        bool exists = await _dbContext.Products.AnyAsync(p => p.Name == product.Name);

        if (exists is false)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task SeedCategories()
    {
        List<ProductCategory> productCategories = new List<ProductCategory> {
                        new ProductCategory { Category = Category.Toys },
                        new ProductCategory { Category = Category.Sports },
                        new ProductCategory { Category = Category.Electronics },
                        new ProductCategory { Category = Category.Miscellaneous },
                        new ProductCategory { Category = Category.Shoes },
                        new ProductCategory { Category = Category.Clothes } };


        foreach (var category in productCategories)
        {
            await addCategoryIfNotExists(category);
        }

    }


    public async Task addCategoryIfNotExists(ProductCategory productCategory)
    {

        bool exists = await _dbContext.ProductCategories.AnyAsync(p => p.Category == productCategory.Category);

        if (exists is false)
        {
            _dbContext.ProductCategories.Add(productCategory);
            await _dbContext.SaveChangesAsync();
        }
    }

}
