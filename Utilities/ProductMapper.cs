using CRJ_Shop.Models;
using CRJ_Shop.Models.SeedModels;

namespace CRJ_Shop.Utilities;

public class ProductMapper
{
    public static Func<SeedProduct, Product> mapSeedToProduct = seedProduct => new Product
    {
        Name = seedProduct.title,
        Price = seedProduct.price,
        Description = seedProduct.description,
        Image = seedProduct.images[0]
    };
}
