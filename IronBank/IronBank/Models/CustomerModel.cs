using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IronBank.Models
{
    public class Customer
    {
        public Int32 Id { get; set; }

        public String Name { get; set; }

        public String LastName { get; set; }

        public virtual IList<Product> Products { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

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