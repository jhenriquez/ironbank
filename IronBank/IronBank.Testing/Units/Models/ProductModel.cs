using System;
using IronBank.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IronBank.Testing.Units.Models
{
    [TestClass]
    public class ProductModel
    {
        ProductService _service;

        [TestInitialize]
        public void TestInitialize()
        {
            _service = new ProductService();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _service = null;
        }

        [TestMethod]
        public void ProductService_Save_ShouldReturnTheProvidedObject()
        {
            var newp = new Product();
            var rtr = _service.Save(newp);
            Assert.IsNotNull(rtr);
            Assert.ReferenceEquals(rtr, newp);
        }

        public void ProductService_Save_NewlyProvidedObjectShouldHaveAnId_WhenReturned()
        {
            var newp = new Product();
            var rtr = _service.Save(newp);
        }
    }
}
