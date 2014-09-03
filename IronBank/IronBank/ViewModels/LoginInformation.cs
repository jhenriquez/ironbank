using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronBank.ViewModels
{
    public class LoginInformation
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}