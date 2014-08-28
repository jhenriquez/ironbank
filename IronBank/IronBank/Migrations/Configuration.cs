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

        protected override void Seed(IronBank.Models.IronBankEntities context)
        {
            var userManager = new UserManager<User>(new UserStore<User>(context));

            userManager.Create(new User() { UserName = "jhenriquez", Name = "Julio", LastName = "Henriquez", Email = "julio.m.henriquez@gmail.com", PhoneNumber = "809-477-7857" }, "password");

            var user = userManager.FindByName("jhenriquez");

            context.Products.Add(new Product() { Customer = user, Type = ProductType.SavingsAccount, Balance = 100 });

            context.SaveChanges();
        }
    }
}
