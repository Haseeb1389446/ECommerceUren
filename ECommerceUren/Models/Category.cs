using System.ComponentModel.DataAnnotations;

namespace ECommerceUren.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Invalid Category")]
        public string CategoryName { get; set; }

        public DateTime Created_At = DateTime.Now;

        public List<Product>? Product { get; set; }
    }
}
