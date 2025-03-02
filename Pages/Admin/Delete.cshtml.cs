using CRJ_Shop.Data;
using CRJ_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRJ_Shop.Pages.Admin;

public class Delete : PageModel
{
    private readonly AppDbContext context;

    public Delete(AppDbContext context)
    {
        this.context = context;
    }

    public Product Products { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return RedirectToPage("/admin/products");
        }

        var products = await context.Products.FirstOrDefaultAsync(e => e.Id == (id));
        if (products == null)
        {
            return RedirectToPage("/admin/products");
        }
        else
        {
            Products = products;
            return Page();
        }
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        var productToDelete = await context.Products.FindAsync(id);
        if (productToDelete == null)
        {
            return NotFound();
        }

        context.Products.Remove(productToDelete); 
        await context.SaveChangesAsync();
        return RedirectToPage("/Admin/Products");
    }
}