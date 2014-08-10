using System;
using System.Collections.Generic;
using IronBank.Models;

namespace IronBank.Testing.Units.Mocks
{
    public class InMemoryProductService : IProductService 
    {
        public IList<Product> productStore = new List<Product>();

        public bool Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetByCustomer(int id)
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
