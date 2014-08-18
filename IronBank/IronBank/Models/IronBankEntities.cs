using System;
using System.Linq;
using System.Data.Entity;


namespace IronBank.Models
{
    public class IronBankEntities : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override int SaveChanges()
        {
            ChangeTracker.Entries()
                  .Where((e) => e.State == EntityState.Added || e.State == EntityState.Modified)
                  .Select((e) => e.State == EntityState.Added ? e.Property("CreatedAt").CurrentValue = DateTime.Now : e.Property("UpdatedAt").CurrentValue = DateTime.Now).Count();

            return base.SaveChanges();
        }
    }
}