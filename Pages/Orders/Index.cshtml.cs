using CRJ_Shop.Data;
using CRJ_Shop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRJ_Shop.Pages.Order
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;


        public IndexModel(AppDbContext appDbContext, UserManager<AppUser> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }

        public List<UserOrder> Orders { get; set; }
        public AppUser? AppUser { get; set; }

        public async Task OnGetAsync()
        {
            AppUser = await _userManager.GetUserAsync(User);
            Orders = await _appDbContext.Orders.Include(o => o.Products).ThenInclude(p => p.Product).Where(o => o.UserId == AppUser.Id).ToListAsync();

        }
    }
}
