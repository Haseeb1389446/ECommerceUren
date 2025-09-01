using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceUren.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductPrice { get; set; }

        public string ProductDescription { get; set; }

        public string ProductStock { get; set; }

        public string ProductImage { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
