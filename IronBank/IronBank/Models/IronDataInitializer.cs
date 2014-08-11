using System.Data.Entity;

namespace IronBank.Models
{
    public class IronDataInitializer : DropCreateDatabaseIfModelChanges<IronBankEntities>
    {
        protected override void Seed(IronBankEntities context)
        {
            context.Customers.Add(new Customer() { Name = "Pablo", LastName = "Batida" });
            context.SaveChanges();
        }
    }
}