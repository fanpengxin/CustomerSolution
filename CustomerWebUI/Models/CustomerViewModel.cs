using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerWebUI.Models
{
    public class CustomerViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} field must have a maximum length of 50 characters")]
        public string? Name { get; set; }
        [Required]
        [Range(0, 110, ErrorMessage = "The {0} field must be between 0 and 110.")]
        public int Age { get; set; }
        [Required]
        [RegularExpression(@"(([a-zA-Z]+[\d]+)[ ]*[a-zA-Z\d]+)", ErrorMessage = "The {0} field must contain both letters and numbers, such as ABC77ZE or ABC7 7ZE.")]
        public string? Postcode { get; set; }
        [Required]
        [Range(0, 2.50, ErrorMessage = "The {0} field must be between 0 and 2.50.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} field must have up to 2 decimal places.")]
        public double Height { get; set; }
    }
}
