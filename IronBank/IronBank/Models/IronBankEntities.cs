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
        public DbSet<ConfiguredServiceInstance> ServiceInstances { get; set; }

        //public override int SaveChanges()
        //{
        //    ChangeTracker.Entries()
        //          .Where((e) => (e.State == EntityState.Added || e.State == EntityState.Modified) && e. ("CreatedAt") != null && e.Property("UpdatedAt") != null)
        //          .Select((e) => e.State == EntityState.Added ? e.Property("CreatedAt").CurrentValue = DateTime.Now : e.Property("UpdatedAt").CurrentValue = DateTime.Now).Count();

        //    return base.SaveChanges();
        //}        
    }
}