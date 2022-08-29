using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSK.DTO
{
    public class UserDTO
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [MaxLength(32, ErrorMessage = "The {0} field only accepts up to 32 characters.")]
        public string Username { get; set; } = string.Empty;

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
