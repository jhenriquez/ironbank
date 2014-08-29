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
    }

    public class ConfiguredServiceInstance
    {
        public Int32 Id { get; set; }
        public Int32 ConfiguredServiceId { get; set; }
        public virtual ConfiguredService Configuration { get; set; }
        public Double Amount { get; set; }
        public DateTime GeneratedAt { get; set; }
        public DateTime? PayBefore { get; set; }
        [DefaultValue(true)]
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
    }

    #region View Models

    public class ServiceConfiguration
    {
        public Int32 ServiceId { get; set; }
        public String ContractReference { get; set; }
    }

    #endregion
}