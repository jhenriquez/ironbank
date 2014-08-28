using System;
using IronBank.Models;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace IronBank.Testing.Units.Models
{
    [TestClass]
    public class ProductModel
    {
        ProductService _service;
        User _mockCustomer;

        [TestInitialize]
        public void TestInitialize()
        {
            _service = new ProductService();
            _mockCustomer = new IronBankEntities().Users.FirstOrDefault();
        }

        [TestMethod]
        public void ProductService_Save_ShouldReturnTheProvidedObject()
        {
            var newp = new Product() { CustomerId = _mockCustomer.Id };
            var rtr = _service.Save(newp);
            Assert.IsNotNull(rtr);
            Assert.ReferenceEquals(rtr, newp);
        }

        [TestMethod]
        public void ProductService_Save_WhenReturned_NewlyProvidedObjectShouldHaveId()
        {
            var newp = new Product() { CustomerId = _mockCustomer.Id };
            var rtr = _service.Save(newp);
            Assert.AreNotEqual(0, rtr.Id);
        }

        [TestMethod]
        public void GetById_Retreives_PreviouslySavedObject()
        {
            var newp = new Product() { CustomerId = _mockCustomer.Id, Type = ProductType.CreditCard };
            var saved = _service.Save(newp);
            var returned = _service.GetById(saved.Id);

            Assert.AreEqual(saved.Id, returned.Id);
            Assert.AreEqual(saved.Type, returned.Type);
        }

        [TestMethod]
        public void GetById_ReturnsNull_WhenNotFound()
        {
            var returned = _service.GetById(10000);
            Assert.IsNull(returned);
        }

        [TestMethod]
        public void GetByCustomer_ReturnsEmptyList_WhenCustomerHasNoProducts()
        {
            var returned = _service.GetByCustomer("fdsdsf");
            Assert.AreEqual(returned.Count, 0);
        }

        [TestMethod]
        public void GetByCustomer_Returns_ListOfProducts_WhenBelongToCustomer()
        {
            var new_one = new Product() { CustomerId = _mockCustomer.Id, Type = ProductType.SavingsAccount };
            var new_two = new Product() { CustomerId = _mockCustomer.Id, Type = ProductType.CheckingAccount };
            var new_three = new Product() { CustomerId = _mockCustomer.Id, Type = ProductType.CreditCard };
            _service.Save(new_one);
            _service.Save(new_two);
            _service.Save(new_three);
            var returned = _service.GetByCustomer(_mockCustomer.Id);

            Assert.IsTrue(returned.Count >= 3);
        }

        [TestMethod]
        public void Delete_RemovesAnEntity()
        {
            var toDelete = new Product() { CustomerId = _mockCustomer.Id, Type = ProductType.CreditCard };
            _service.Save(toDelete);
            var checkSaved = _service.GetById(toDelete.Id);
            Assert.IsNotNull(checkSaved);
            _service.Delete(toDelete);
            var checkDeleted = _service.GetById(toDelete.Id);
            Assert.IsNull(checkDeleted);
        }

        [TestMethod]
        public void DeleteById_RemovesAnEntity()
        {
            var toDelete = new Product() { CustomerId = _mockCustomer.Id, Type = ProductType.CreditCard };
            _service.Save(toDelete);
            _service.DeleteById(toDelete.Id);
            var checkDeleted = _service.GetById(toDelete.Id);
            Assert.IsNull(checkDeleted);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteById_ThrowsException_WhenProvidedIdDoesNotExists()
        {
            _service.DeleteById(1000);
        }
    }
}
