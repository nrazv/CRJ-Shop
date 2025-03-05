using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CRJ_Shop.Models
{
    [Index(nameof(Category), IsUnique = true)]
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        public Category Category { get; set; }
    }
}
