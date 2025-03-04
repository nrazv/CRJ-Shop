using CRJ_Shop.Data;
using CRJ_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRJ_Shop.Pages;

public class IndexModel : PageModel
{
    // Property
    private readonly AppDbContext dbContext;


    public List<Product> Products { get; set; }

    // Konstruktor
    public IndexModel(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    // Method
    public async Task OnGet()
    {
        Products = await dbContext.Products.ToListAsync();
    }
}
