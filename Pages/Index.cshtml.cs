using CRJ_Shop.Data;
using CRJ_Shop.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRJ_Shop.Pages;

public class IndexModel : PageModel
{
    // Properties
    private readonly AppDbContext dbContext;

    public bool MoreProducts { get; set; }

    public int ProductsToSkip { get; set; }

    public List<Product> Products { get; set; }

    // Constructors
    public IndexModel(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    // Methods
    public async Task OnGet()
    {
        Products = await dbContext.Products.Take(12).ToListAsync();
    }

    public async Task OnPost()
    {
        Products = await dbContext.Products.ToListAsync();
    }


}
