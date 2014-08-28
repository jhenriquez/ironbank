using System;
using System.Collections.Generic;
using IronBank.Models;

namespace IronBank.Testing.Units.Mocks
{
    public class InMemoryProductService : IProductService 
    {
        public IList<Product> productStore = new List<Product>();

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(Int32 Id) { }

        public IList<Product> GetByCustomer(String id)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Product Save(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
