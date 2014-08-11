using System.Data.Entity;

namespace IronBank.Models
{
    public class IronBankEntities : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}