using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment3_.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal Price { get; set; }
    }
}
