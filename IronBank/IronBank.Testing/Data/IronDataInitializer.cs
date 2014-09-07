using System.Data.Entity;
using IronBank.Models;
using System.Linq;

namespace IronBank.Testing.Data
{
    public class IronDataInitializer : DropCreateDatabaseAlways<IronBankEntities>
    {
        private AccountNumberGenerator generator = new AccountNumberGenerator();

        protected override void Seed(IronBankEntities context)
        {
            context.Users.Add(new User() { UserName = "DumpUser" });
            context.Products.Add(
                new Product() { 
                    Customer = context.Users.FirstOrDefault(),
                    Currency = ProductCurrency.Pesos,
                    Type = ProductType.CheckingAccount, 
                    AccountNumber = generator.Generate(15),
                    Balance = 10000.00
                });
            context.Products.Add(
                new Product()
                {
                    Customer = context.Users.FirstOrDefault(),
                    Currency = ProductCurrency.Pesos,
                    Type = ProductType.CheckingAccount,
                    AccountNumber = generator.Generate(15),
                    Balance = 500.00
                });

            context.SaveChanges();
            
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
