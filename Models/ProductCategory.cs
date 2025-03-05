using System.ComponentModel.DataAnnotations;

namespace CRJ_Shop.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        public Category Category { get; set; }
    }
}
