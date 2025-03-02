using CRJ_Shop.Data;
using CRJ_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRJ_Shop.Pages.Admin;

public class Edit : PageModel
{
    private readonly AppDbContext _context;

    public Edit(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Product Product { get; set; } = default;
    
    public async Task<IActionResult> OnGet(int? id)
    {
        if (id == null)
        {
            return RedirectToPage("/Index");
        }

        var products = await _context.Products.FirstOrDefaultAsync(e => e.Id == id);
        if (products == null)
        {
            return RedirectToPage("/Index");
        }
        else
        {
            Product = products;
            return Page();
        }
    }
    
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                _context.Products.Update(Product);
                await _context.SaveChangesAsync();
                return RedirectToPage("Admin/Products");
            }
        }
}