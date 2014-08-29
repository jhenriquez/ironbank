namespace IronBank.Migrations
{
    using IronBank.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IronBank.Models.IronBankEntities>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(IronBankEntities context)
        {
            SeedDefaultUser(context);
            SeedProductsForDefaultUser(context);
            SeedAvailableServices(context);
            context.SaveChanges();
        }

        public void SeedDefaultUser(IronBankEntities context)
        {
            var userManager = new UserManager<User>(new UserStore<User>(context));
            userManager.Create(new User() { UserName = "jhenriquez", Name = "Julio", LastName = "Henriquez", Email = "julio.m.henriquez@gmail.com", PhoneNumber = "809-477-7857" }, "password");
        }

        public void SeedProductsForDefaultUser(IronBankEntities context)
        {
            var userManager = new UserManager<User>(new UserStore<User>(context));
            var user = userManager.FindByName("jhenriquez");
            context.Products.Add(new Product() { Customer = user, Type = ProductType.SavingsAccount, Balance = 100 });
        }

        public void SeedAvailableServices(IronBankEntities context)
        {
            context.AvailableServices.Add(new AvailableService() { Name = "Tricom", Description = "Telecommunications Provider" });
            context.AvailableServices.Add(new AvailableService() { Name = "Claro", Description = "Telecommunications Provider" });
            context.AvailableServices.Add(new AvailableService() { Name = "Orange", Description = "Telecommunications Provider" });
            context.AvailableServices.Add(new AvailableService() { Name = "Viva", Description = "Telecommunications Provider" });
        }
    }
}
