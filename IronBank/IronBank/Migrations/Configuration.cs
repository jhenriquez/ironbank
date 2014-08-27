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
            AutomaticMigrationsEnabled = true;
            ContextKey = "IronBank.Models.IronBankEntities";
        }

        protected override void Seed(IronBank.Models.IronBankEntities context)
        {   
            var customer = new Customer() { Name = "Pablo", LastName = "Batida" };
            context.Customers.Add(customer);

            context.Products.Add(new Product() { Customer = customer, Type = ProductType.SavingsAccount, Balance = 100 });

            context.SaveChanges();

            var userManager = new UserManager<User>(new UserStore<User>(context));

            userManager.Create(new User() { Customer = customer, UserName = "jhenriquez" }, "password");
        }
    }
}
