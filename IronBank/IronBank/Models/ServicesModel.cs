using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace IronBank.Models
{
    public class AvailableService
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
    }

    public class ConfiguredService
    {
        public Int32 Id { get; set; }
        public String UserId { get; set; }
        public virtual User User { get; set; }
        public Int32 ServiceId { get; set; }
        public virtual AvailableService Service { get; set; }
        public virtual IList<ConfiguredServiceInstance> Instances { get; set; }
        public String ContractReference { get; set; }

        [NotMapped]
        public Boolean HasPendingInstances
        {
            get
            {
                if (Instances == null)
                    return false;
                return Instances.Where((i) => i.IsPending).Count() > 0;
            }
        }

        [NotMapped]
        public Double PendingBalance
        {
            get
            {
                if (!HasPendingInstances)
                    return 0.00;
                return Instances.Where((i) => i.IsPending).Sum((i) => i.Amount);
            }
        }
    }

    public class ConfiguredServiceInstance
    {
        public ConfiguredServiceInstance()
        {
            IsPending = true;
        }

        public Int32 Id { get; set; }
        public Int32 ConfiguredServiceId { get; set; }
        public virtual ConfiguredService Configuration { get; set; }
        public virtual IList<ServiceInstancePayment> Payments { get; set; } 
        public Double Amount { get; set; }
        public DateTime GeneratedAt { get; set; }
        public DateTime? PayBefore { get; set; }
        public Boolean IsPending { get; set; }

        [NotMapped]
        public Boolean HasExpired
        {
            get
            {
                if (PayBefore.HasValue)
                    return DateTime.Today > PayBefore.Value.Date;
                return false;
            }
        }

        [NotMapped]
        public Double TotalPayments
        {
            get
            {
                if (Payments == null)
                    return 0.00;
                return Payments.Sum((p) => p.Amount);
            }
        }
    }

    public class ServiceInstancePayment
    {
        public Int32 Id { get; set; }
        public Int32 ConfiguredServiceInstanceId { get; set; }
        public virtual ConfiguredServiceInstance ConfiguredServiceInstace { get; set; }
        public Double Amount { get; set; }
    }
}