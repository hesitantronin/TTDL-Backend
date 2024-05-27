using System.ComponentModel.DataAnnotations;

namespace TTDL_Backend.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Uname { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
