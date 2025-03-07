using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CRJ_Shop.Models;

public class AppUser : IdentityUser
{
    [Required]
    public string FirsName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    [Required]
    public string Address { get; set; } = null!;

}
