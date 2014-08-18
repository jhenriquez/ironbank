using System.Data.Entity;
using IronBank.Models;
using System.Linq;

namespace IronBank.Testing.Data
{
    public class IronDataInitializer : DropCreateDatabaseAlways<IronBankEntities>
    {
        protected override void Seed(IronBankEntities context)
        {
            context.Customers.Add(new Customer { Name = "Pablo", LastName = "Batida" });
            context.Products.Add(new Product() { Customer = context.Customers.FirstOrDefault(), Currency = ProductCurrency.Pesos, Type = ProductType.CheckingAccount });
            
            /*
             * Transactions initialization data. Warning: Some tests may depend on this initialization data. 
             * 
             */

            context.Transactions.Add(new Transaction() { Type = TransactionType.Credit, Amount = 100.00, Status = TransactionStatus.InTransit, Product = context.Products.FirstOrDefault() });
            context.Transactions.Add(new Transaction() { Type = TransactionType.Credit, Amount = 100.00, Status = TransactionStatus.Completed, Product = context.Products.FirstOrDefault() });
            context.Transactions.Add(new Transaction() { Type = TransactionType.Credit, Amount = 100.00, Status = TransactionStatus.Completed, Product = context.Products.FirstOrDefault() });
            context.Transactions.Add(new Transaction() { Type = TransactionType.Debit, Amount = 100.00,  Status = TransactionStatus.Completed, Product = context.Products.FirstOrDefault() });

            context.SaveChanges();
        }
    }
}
