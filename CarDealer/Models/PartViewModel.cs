using System.ComponentModel.DataAnnotations;

namespace CarDealer.Models
{
    public class PartViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Price cannot be 0")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "số lượng không thể là 0")]
        public int Quantity { get; set; }

        [Required]
        public int SupplierId { get; set; }
    }

}
