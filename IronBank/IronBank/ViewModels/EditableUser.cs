using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronBank.ViewModels
{
    public class EditableUser
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
    }
}