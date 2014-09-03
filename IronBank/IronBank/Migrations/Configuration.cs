namespace IronBank.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using IronBank.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<IronBank.Models.IronBankEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IronBankEntities context)
        {
            SeedDefaultUser(context);
            SeedProductsForDefaultUsers(context);
            SeedAvailableServices(context);
            SeedConfiguredServices(context);
            context.SaveChanges();
        }

        public void SeedDefaultUser(IronBankEntities context)
        {
            var userManager = new UserManager<User>(new UserStore<User>(context));
            userManager.Create(new User() { UserName = "jhenriquez", Name = "Julio", LastName = "Henriquez", Email = "julio.m.henriquez@gmail.com", PhoneNumber = "809-477-7857" }, "password");
            userManager.Create(new User() { UserName = "csanchez", Name = "Claudio", LastName = "Sanchez", Email = "csanchez@megsoftconsulting.com", PhoneNumber = "" }, "password");
        }

        public void SeedProductsForDefaultUsers(IronBankEntities context)
        {
            var productService = new ProductService(context);
            var userManager = new UserManager<User>(new UserStore<User>(context));

            var user = userManager.FindByName("jhenriquez");

            if (productService.GetByCustomer(user.Id).Count > 0) return;

            productService.Create(user, ProductType.SavingsAccount, ProductCurrency.Pesos, 1000.00);
            productService.Create(user, ProductType.CheckingAccount, ProductCurrency.Pesos, 2000.00);

            user = userManager.FindByName("csanchez");

            if (productService.GetByCustomer(user.Id).Count > 0) return;

            productService.Create(user, ProductType.SavingsAccount, ProductCurrency.Pesos, 25000.00);
            productService.Create(user, ProductType.CheckingAccount, ProductCurrency.Pesos, 50000.00);
        }

        public void SeedAvailableServices(IronBankEntities context)
        {
            if (context.AvailableServices.Count() > 0) return;
            context.AvailableServices.Add(new AvailableService() { Name = "Tricom", Description = "Telecommunications Provider" });
            context.AvailableServices.Add(new AvailableService() { Name = "Claro", Description = "Telecommunications Provider" });
            context.AvailableServices.Add(new AvailableService() { Name = "Orange", Description = "Telecommunications Provider" });
            context.AvailableServices.Add(new AvailableService() { Name = "Viva", Description = "Telecommunications Provider" });
            context.SaveChanges();
        }

        public void SeedConfiguredServices(IronBankEntities context)
        {
            var userManager = new UserManager<User>(new UserStore<User>(context));
            var user = userManager.FindByName("jhenriquez");

            context.ConfiguredServices.Add(new ConfiguredService() { Service = context.AvailableServices.FirstOrDefault(), User = user, ContractReference = "8094777857" });

            context.ServiceInstances.Add(
                new ConfiguredServiceInstance() { 
                    Configuration = context.ConfiguredServices.FirstOrDefault(),
                    GeneratedAt = DateTime.Now,
                    IsPending = true,
                    Amount = 1492.00,
                    PayBefore = DateTime.Now.AddDays(2)  }
                );
        }
    }
}
