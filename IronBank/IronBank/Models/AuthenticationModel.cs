using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IronBank.Models
{
    public class LoginInformation
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}