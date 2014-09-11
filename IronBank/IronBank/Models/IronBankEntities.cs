using System;
using System.Linq;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;


namespace IronBank.Models
{
    public class IronBankEntities : IdentityDbContext<User>
    {
        public IronBankEntities() : base("IronBankEntities") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<AvailableService> AvailableServices { get; set; }
        public DbSet<ConfiguredService> ConfiguredServices { get; set; }
        public DbSet<ServiceBill> ServiceBilling { get; set; }
        public DbSet<ServicePayment> ServicePayments { get; set; }
    }
}