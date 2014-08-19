using Microsoft.VisualStudio.TestTools.UnitTesting;
using IronBank.Models;
using System.Collections.Generic;
using System;

namespace IronBank.Testing.Units.Models
{
    [TestClass]
    public class TransactionModel
    {
        private ITransactionService _service;
        
        [TestInitialize]
        public void TestInitialize()
        {
            _service = new TransactionService();
        }
        
        [TestMethod]
        public void GetByType_ShouldNotReturnNull()
        {
            Assert.IsNotNull(_service.GetByType(TransactionType.Credit));
        }

        [TestMethod]
        public void GetByType_ShouldActuallyReturnData_WhenExists()
        {
            // I won't create transactions here. I feel that would contaminate the test unless we really need to add a save operation on this service.
            // So, this test depends on the data initializer. Which I'm not sure is alright either... :(
            Assert.IsTrue(_service.GetByType(TransactionType.Credit).Count >= 3);
        }

        [TestMethod]
        public void GetByProductId_ShouldNotBeNull()
        {
            Assert.IsNotNull(_service.GetByProductId(10000));
        }

        [TestMethod]
        public void GetByProductId_ShouldActuallyReturnData_WhenExists()
        {
            Assert.IsTrue(_service.GetByProductId(1).Count >= 4);
        }

        [TestMethod]
        public void GetByProductIdAndDate_Should_Not_ReturnNull()
        {
            Assert.IsNotNull(_service.GetByProductIdAndDate(1, null, null));
        }

        [TestMethod]
        public void GetByProductIdAndDate_Dates_Are_Optional()
        {
            var allTransactions = _service.GetByProductId(1);
            var allAgain = _service.GetByProductIdAndDate(1, null, null);
            Assert.AreEqual(allTransactions.Count, allAgain.Count);
        }

        [TestMethod]
        public void GetByProductIdAndDate_Should_Work_With_Only_StartDate()
        {
            var transactions = _service.GetByProductIdAndDate(1, DateTime.Today, null);
            foreach (var transaction in transactions)
            {
                Assert.IsTrue(transaction.CreatedAt >= DateTime.Today);
            }
        }

        [TestMethod]
        public void GetByProductIdAndDate_Should_Work_With_Only_EndDate()
        {
            var transactions = _service.GetByProductIdAndDate(1, null, DateTime.Today);
            foreach (var transaction in transactions)
            {
                Assert.IsTrue(transaction.CreatedAt <= DateTime.Today);
            }
        }
    }
}
