using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerWebApi.Models
{

    [Table("customer", Schema = "dbo")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("customer_id")]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must have a maximum length of 50 characters")]
        [Column("customer_name")]
        public string? Name { get; set; }
        [Required]
        [Range(0, 110, ErrorMessage = "The {0} must be between 0 and 110.")]
        [Column("customer_age")]
        public int Age { get; set; }
        [Required]
        [RegularExpression(@"(([a-zA-Z]+[\d]+)[ ]*[a-zA-Z\d]+)", ErrorMessage = "The {0} field must contain both letters and numbers, such as ABC77ZE.")]
        public string? Postcode { get; set; }
        [Required]
        [Range(0, 2.50, ErrorMessage = "The {0} must be between 0 and 2.50.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "The {0} must have up to 2 decimal places.")]
        [Column("customer_height")]
        public double Height { get; set; }
    }
}
