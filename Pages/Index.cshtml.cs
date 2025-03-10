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

        if (!_roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult())
        {
            var customerRole = new IdentityRole("Customer");
            var adminRole = new IdentityRole("Admin");
            await _roleManager.CreateAsync(adminRole);
            await _roleManager.CreateAsync(customerRole);
        }

        var adminUsers = _userManager.GetUsersInRoleAsync("Admin").Result;

        if (adminUsers.Count == 0)
        {
            var adminEmail = "admin@shop.com";
            var adminUser = CreateUser();
            adminUser.FirsName = "Admin";
            adminUser.LastName = "Admin";
            adminUser.Address = "crjshop.com";
            adminUser.Email = adminEmail;
            await _userStore.SetUserNameAsync(adminUser, adminEmail, CancellationToken.None);

            var result = await _userManager.CreateAsync(adminUser, "Password123!");
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(adminUser, "Admin");

            }

        }

    }


    private AppUser CreateUser()
    {
        try
        {
            return Activator.CreateInstance<AppUser>();
        }
        catch
        {
            throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}");
        }
    }
}
