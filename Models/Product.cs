using System.ComponentModel.DataAnnotations;

namespace CRJ_Shop.Models
{
	public class Product
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string Name { get; set; }

		[MaxLength(100)] public string? Description { get; set; } = "";

		public Double Price { get; set; }
		public string? Category { get; set; } = "";
		public string? Image { get; set; } = "";


	}
}
