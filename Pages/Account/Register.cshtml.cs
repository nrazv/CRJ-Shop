using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRJ_Shop.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var roleName = "Admin"; 
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                var role = new IdentityRole(roleName);
                await _roleManager.CreateAsync(role);
            }

            var user = new IdentityUser
            {
                UserName = Email,
                Email = Email
            };
            var result = await _userManager.CreateAsync(user, Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, roleName);

                return RedirectToPage("/Account/Login");
            }

            ErrorMessage = "Error, try again.";
            return Page();
        }
    }
}
