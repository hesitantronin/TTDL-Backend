using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [MaxLength(50)]
        [ForeignKey("Chair")]
        public string? CurrentChairId { get; set; }

        public Chair CurrentChair { get; set; } // Navigation property
    }
}
