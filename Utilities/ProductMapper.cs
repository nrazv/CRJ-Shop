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
        Categories = new List<ProductCategory>()
    };

    public static Category GetCategory(string categoryName) => categoryName switch
    {
        "Shoes" => Category.Shoes,
        "Electronics" => Category.Electronics,
        "Clothes" => Category.Clothes,
        "Toys" => Category.Toys,
        "Sports" => Category.Sports,
        "Miscellaneous" => Category.Miscellaneous,
        _ => Category.Miscellaneous,
    };
}
