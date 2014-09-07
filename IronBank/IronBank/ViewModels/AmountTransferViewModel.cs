using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronBank.ViewModels
{
    public class AmountTransferViewModel
    {
        public AmountTransferViewModel()
        {
            AvailableProducts = new List<ProductViewModel>();
        }

        public IList<ProductViewModel> AvailableProducts { get; set; }
        public String Source { get; set; }
        public String Target { get; set; }
        public Double Amount { get; set; }
    }
}