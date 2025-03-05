using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CRJ_Shop.Data;
using CRJ_Shop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CRJ_Shop.Pages
{
    public class CartModel : PageModel
    {
        private readonly AppDbContext _context;

        public CartModel(AppDbContext context)
        {
            _context = context;
        }

        public List<CartItem> CartItem { get; set; }
        public bool SuccessMessage { get; set; }

        public async Task OnGetAsync()
        {
            CartItem = await _context.CartItems
                .Include(c => c.Product)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostRemoveFromCart(int itemId)
        {
            var cartItem = await _context.CartItems.FindAsync(itemId);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAddToCart(int productId)
        {
            var cartItem = await _context.CartItems.FirstOrDefaultAsync(m => m.ProductId == productId);
            var product = await _context.Products.FirstOrDefaultAsync(m => m.Id == productId);


            if (cartItem == null)
            {
                cartItem = new CartItem()
                {
                    ProductId = productId,
                    Quantity = 1,
                    Product = product
                };
                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }

            TempData["AddedProductId"] = productId;
            await _context.SaveChangesAsync();
            return RedirectToPage("/Cart");
        }
    }
}