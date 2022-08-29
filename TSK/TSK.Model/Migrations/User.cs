using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TSK.Model
{
    [Table(nameof(User))]
    public class User
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(32, ErrorMessage = "The {0} field only accepts up to 32 characters.")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(64, ErrorMessage = "The {0} field only accepts up to 64 characters.")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [MaxLength(50, ErrorMessage = "The {0} field only accepts up to 50 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50, ErrorMessage = "The {0} field only accepts up to 50 characters.")]
        public string Lastname { get; set; } = string.Empty;

        [Required]
        [MaxLength(62, ErrorMessage = "The {0} field only accepts up to 62 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        public bool EmailConfirmed { get; set; } = false;
    }
}