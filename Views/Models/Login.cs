using System.ComponentModel.DataAnnotations;

namespace DoSAttackPrevention.Models
{
    public class Login
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
