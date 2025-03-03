using System.Threading.Tasks;
using CRJ_Shop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CRJ_Shop.Models; 

namespace CRJ_Shop.Pages.Products
{
    public class ProductModel : PageModel
    {
        private readonly AppDbContext _context;

        public ProductModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; } 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products.FindAsync(id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}