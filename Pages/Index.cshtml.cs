using CRJ_Shop.Data;
using CRJ_Shop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRJ_Shop.Pages;

public class IndexModel : PageModel
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IUserStore<AppUser> _userStore;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly AppDbContext dbContext;


    public List<Product> Products { get; set; }

    // Konstruktor
    public IndexModel(
            AppDbContext dbContext,
            UserManager<AppUser> userManager,
            IUserStore<AppUser> userStore,
            RoleManager<IdentityRole> roleManager)
    {
        this.dbContext = dbContext;
        _userManager = userManager;
        _userStore = userStore;
        _roleManager = roleManager;


    }

    // Method
    public async Task OnGet()
    {

        Products = await dbContext.Products.ToListAsync();




    }



}
