using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public String Name { get; set; }

        public String LastName { get; set; }

        public virtual IList<Product> Products { get; set; }

        [NotMapped]
        public String FullName
        {
            get
            {
                return Name.Trim() + " " + LastName.Trim();
            }
        }
    }

    public class EditableUser
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
    }
}