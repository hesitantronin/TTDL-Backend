using System.ComponentModel.DataAnnotations;

namespace TTDL_Backend.Models
{
    public class Patient
    {
        [Key]
        public string PatientId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public Chair CurrentChair { get; set; }
    }
}