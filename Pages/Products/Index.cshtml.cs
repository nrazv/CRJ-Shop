using CRJ_Shop.Data;
using CRJ_Shop.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRJ_Shop.Pages.Products;

public class Index : PageModel
{
    private readonly AppDbContext _database;

    public Index(AppDbContext database)
    {
        _database = database;
    }
    
    public List<Product> ProductList { get; set; }
    public async Task OnGet()
    {
        ProductList = await _database.Products.ToListAsync();
    }
}