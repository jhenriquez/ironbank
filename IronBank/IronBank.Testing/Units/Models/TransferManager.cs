using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace IronBank.Testing.Units.Models
{
    [TestClass]
    public class TransferManager
    {
        IronBank.Models.TransferManager manager;
        IronBank.Models.IronBankEntities entities;

        [TestInitialize]
        public void TestMethodInitialize()
        {
            entities = new IronBank.Models.IronBankEntities();
            manager = new IronBank.Models.TransferManager(entities);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExecuteTransference_ThrowsInvalidOperation_WhenSourceBalanceIsLowBelowAmount()
        {
            var source = entities.Products.ToArray()[1];
            var target = entities.Products.ToArray()[0];

            Assert.IsTrue(target.Balance > source.Balance);

            manager.SetSource(source.AccountNumber);
            manager.SetTarget(target.AccountNumber);

            manager.Amount = 1000.00;

            manager.ExecuteTransference();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExecuteTransference_ThrowsInvalidOperation_WhenSourceOrTargetNotProvided()
        {
            manager.Amount = 1000.00;
            manager.ExecuteTransference();
        }
    }
}
