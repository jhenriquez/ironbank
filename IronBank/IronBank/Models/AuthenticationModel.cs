using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IronBank.Models
{
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
}