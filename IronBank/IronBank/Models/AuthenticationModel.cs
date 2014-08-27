using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IronBank.Models
{
    public class LoginInformation
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }

    public class User : IdentityUser
    {
        public Int32 CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}