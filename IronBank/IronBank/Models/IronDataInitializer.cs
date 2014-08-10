using System.Data.Entity;

namespace IronBank.Models
{
    public class IronDataInitializer : DropCreateDatabaseAlways<IronBankEntities>
    {
        protected override void Seed(IronBankEntities context)
        {
            context.Products.Add(new Product { Type = ProductType.SavingsAccount });
            context.SaveChanges();
        }
    }
}