using CRJ_Shop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CRJ_Shop.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserStore<IdentityUser> _userStore;

        public RegisterModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,

               IUserStore<IdentityUser> userStore)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userStore = userStore;
        }

        [BindProperty]
        public InputModel Input { get; set; }


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

            var user = CreateUser();
            await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, Input.Password);

            if (result.Succeeded)
            {
                user.FirsName = Input.FirstName;
                user.LastName = Input.LastName;
                user.Address = Input.Address;
                await _userManager.AddToRoleAsync(user, "User");

                return RedirectToPage("/Account/Login");
            }

            //var roleName = "User";
            //var roleExist = await _roleManager.RoleExistsAsync(roleName);
            //if (!roleExist)
            //{
            //    var role = new IdentityRole(roleName);
            //    await _roleManager.CreateAsync(role);
            //}

            //var user = new IdentityUser
            //{
            //    UserName = Email,
            //    Email = Email
            //};
            //var result = await _userManager.CreateAsync(user, Password);

            //if (result.Succeeded)
            //{
            //    await _userManager.AddToRoleAsync(user, roleName);

            //    return RedirectToPage("/Account/Login");
            //}

            ErrorMessage = "Error, try again.";
            return Page();
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

    public class InputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string Address { get; set; }

    }
}
