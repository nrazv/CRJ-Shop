using CRJ_Shop.Data;
using CRJ_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRJ_Shop.Pages.Admin;

public class Create : PageModel
{
    private readonly AppDbContext _context;
    [BindProperty] public Product CreateProduct { get; set; } = new Product();

    private string ErrorMessage { get; set; }
    public Create(AppDbContext context)
    {
        _context = context;
    }
    public void OnGet()
    {
    }

    public void OnPost()
    {
        if (!ModelState.IsValid)
        {
            ErrorMessage = "Please provide all the req fields!";
        }
        
        Product product = new Product()
        {
            Name = CreateProduct.Name,
            Description = CreateProduct.Description,
            Price = CreateProduct.Price,
            Category = CreateProduct.Category,
        };

       
        _context.Products.Add(product);
        _context.SaveChanges();
        Response.Redirect("/Admin/Products/");
    }
}