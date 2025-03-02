﻿using CRJ_Shop.Data;
using CRJ_Shop.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRJ_Shop.Pages.Admin;

public class Products : PageModel
{
	private readonly AppDbContext _database;

	public Products(AppDbContext database)
	{
		_database = database;
	}

	public List<Product> ProductList { get; set; }
	public async Task OnGetAsync()
	{
		ProductList = await _database.Products.ToListAsync();
	}
}