using IronBank.Models;
using System;
using System.Collections.Generic;

namespace IronBank.ViewModels
{
    public class ServiceConfiguration
    {
        public Int32 ServiceId { get; set; }
        public String ContractReference { get; set; }
        public IList<AvailableService> AvailableServices { get; set; }
    }
}