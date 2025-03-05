using CRJ_Shop.Models;
using CRJ_Shop.Models.SeedModels;

namespace CRJ_Shop.Utilities;

public class ProductMapper
{
    public static Func<SeedProduct, Product> mapSeedToProduct = seedProduct => new Product
    {
        Name = seedProduct.title,
        Title = seedProduct.slug,
        Price = seedProduct.price,
        Description = seedProduct.description,
        Image = seedProduct.images[0],
        Categories = [(ProductCategory)Enum.Parse(typeof(ProductCategory), seedProduct.category.name)]
    };

}
