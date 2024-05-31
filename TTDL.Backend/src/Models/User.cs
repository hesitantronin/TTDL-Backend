using System.ComponentModel.DataAnnotations;
using TTDL_Backend.Helpers;

namespace TTDL_Backend.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Uname { get; set; }

        private string _password;

        [Required]
        [MaxLength(100)]
        public string Password
        { 
            get => _password; 
            set => _password = PasswordHasher.Hash(value); 
        }
    }
}
