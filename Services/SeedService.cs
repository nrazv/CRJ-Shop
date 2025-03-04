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
                await addIfNotExists(product);
            }
            await _dbContext.SaveChangesAsync();
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
        }
    }

}
