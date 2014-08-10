using System.Data.Entity;

namespace IronBank.Models
{
    public class IronBankEntities : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}