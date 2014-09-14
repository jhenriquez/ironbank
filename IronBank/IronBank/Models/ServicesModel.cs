using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        public Int32 ServiceBillId { get; set; }
        public virtual AvailableService Service { get; set; }
        public virtual ServiceBill Billing { get; set; }
        public String ContractReference { get; set; }

        [NotMapped]
        public Double PendingBalance
        {
            get
            {
                if (Billing == null)
                    return 0.00;
                return Billing.Balance;
            }
        }
    }

    public class ServiceBill
    {
        public Int32 Id { get; set; }
        [Required]
        public Int32 ConfiguredServiceId { get; set; }
        public virtual IList<ServicePayment> Payments { get; set; } 
        public Double Amount { get; set; }
        public DateTime GeneratedAt { get; set; }
        public DateTime? PayBefore { get; set; }

        [NotMapped]
        public Double Balance
        {
            get { return Amount - TotalPayments; }
        }

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

    public class ServicePayment
    {
        public Int32 Id { get; set; }
        public Int32 ServiceBillId { get; set; }
        public virtual ServiceBill Bill { get; set; }
        public Double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}