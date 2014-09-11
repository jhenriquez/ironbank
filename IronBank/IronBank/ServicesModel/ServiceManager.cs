using IronBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronBank.ServicesModel
{
    public class ServiceManager
    {
        private readonly IronBankEntities db;
        private User contextUser;

        public ServiceManager() : this(new IronBankEntities()) { }

        public ServiceManager(IronBankEntities context)
        {
            if (context == null)
                throw new ArgumentNullException("ServiceManager: context can not be null.");
            db = context;
        }

        public IList<AvailableService> GetAvailableServices()
        {
            return db.AvailableServices.ToList();
        }

        public ServiceManager SetContextUser(User user)
        {
            if (user == null || String.IsNullOrEmpty(user.Id))
                throw new ArgumentException("ServiceManager: The provided User is invalid. It's either null or has not been persited.");
            contextUser = user;
            return this;
        }

        public IList<ConfiguredService> GetConfiguredServices()
        {
            if (contextUser == null)
                throw new InvalidOperationException("ServiceManager: A context user has not been said. You need to provide one.");
            return db.ConfiguredServices.Where((s) => s.User.Id == contextUser.Id).ToList();
        }

        public IList<ConfiguredService> GetConfiguredServices(User user)
        {
            return db.ConfiguredServices.Where((s) => s.User.Id == user.Id).ToList();
        }

        public ConfiguredService Configure(Int32 serviceId, String contractReference)
        {
            if (contextUser == null)
                throw new InvalidOperationException("ServiceManager: A context user has not been said. You need to provide one.");

            var newConfiguration = 
                new ConfiguredService() { 
                        ServiceId = serviceId, 
                        ContractReference = contractReference,
                        User = contextUser 
                };

            return ValidateAndSave(newConfiguration);
        }

        public ConfiguredService Configure(Int32 serviceId, String contractReference, User user)
        {
            if (user == null || String.IsNullOrEmpty(user.Id))
                throw new ArgumentException("ServiceManager: The provided User is invalid. It's either null or has not been persited.");

            var newConfiguration =
                new ConfiguredService()
                {
                    ServiceId = serviceId,
                    ContractReference = contractReference,
                    User = user
                };

            return ValidateAndSave(newConfiguration);
        }

        public ServiceBill CreateServiceBill(ConfiguredService service, Double amount, DateTime? payBefore, Boolean consolidate)
        {
            var billing = new ServiceBill() { Amount = amount, ConfiguredServiceId = service.Id, GeneratedAt = DateTime.Now };

            if (payBefore.HasValue)
                billing.PayBefore = DateTime.Today.AddDays(15);

            if (consolidate)
                billing.Amount += service.PendingBalance;

            service.Billing = billing;

            db.Entry(service).State = System.Data.Entity.EntityState.Modified;
            db.ServiceBilling.Add(billing);
            db.SaveChanges();

            return billing;
        }

        private ConfiguredService ValidateAndSave(ConfiguredService newConfiguration)
        {
            ValidateIsNonExistent(newConfiguration);

            db.ConfiguredServices.Add(newConfiguration);
            db.SaveChanges();

            return newConfiguration;
        }

        private void ValidateIsNonExistent(ConfiguredService newConfiguration)
        {
            var isExistentConfiguration =
                db.ConfiguredServices.Where((s) =>
                    (s.ContractReference == newConfiguration.ContractReference && s.UserId == newConfiguration.User.Id) ||
                    (s.Service.Id == newConfiguration.ServiceId && s.ContractReference == newConfiguration.ContractReference && s.UserId == newConfiguration.User.Id))
                    .Count() > 0;

            if (isExistentConfiguration)
                throw new InvalidOperationException("Service Contract Already In Place.");
        }
    }
}