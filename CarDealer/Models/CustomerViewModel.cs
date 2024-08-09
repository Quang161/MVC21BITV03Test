using System.ComponentModel.DataAnnotations;

namespace CarDealer.Models
{
    public class CustomerViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}
