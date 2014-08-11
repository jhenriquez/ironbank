using System.Data.Entity;
using IronBank.Models;

namespace IronBank.Testing.Data
{
    public class IronDataInitializer : DropCreateDatabaseAlways<IronBankEntities>
    {
        protected override void Seed(IronBankEntities context)
        {
            context.Customers.Add(new Customer { Name = "Pablo", LastName = "Batida" });
            context.SaveChanges();
        }
    }
}