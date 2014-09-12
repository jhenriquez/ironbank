using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronBank.ViewModels
{
    public class ServiceDetailsViewModel
    {
        public Int32 ServiceId { get; set; }
        public String Contract { get; set; }
        public String Provider { get; set; }
        public Double PaymentAmount { get; set; }
        public String PaymentAccount { get; set; }
        public IList<ProductViewModel> CustomerAccounts { get; set; }
    }
}