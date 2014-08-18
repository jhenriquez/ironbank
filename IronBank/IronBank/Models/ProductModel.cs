using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IronBank.Models
{
    public enum ProductType
    {
        SavingsAccount,
        CheckingAccount,
        CreditCard
    }

    public enum ProductCurrency
    {
        Pesos,
        Dollars
    }

    public class Product
    {
        public Int32 Id { get; set; }

        public ProductType Type { get; set; }

        public ProductCurrency Currency { get; set; }

        public Int32 CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [NotMapped]
        public Double Balance { get; set; }

        [NotMapped]
        public Double AvailableBalance { get; set; }
    }

    public interface IProductService
    {
        void Delete(Product product);
        void DeleteById(Int32 id);
        IList<Product> GetByCustomer(Int32 id);
        Product GetById(Int32 id);
        Product Save(Product product);
    }

    public class ProductService : IProductService
    {
        private IronBankEntities _context;
        private ITransactionService _transactionService;

        private ProductService(IronBankEntities context)
        {
            if (context == null)
                throw new ArgumentNullException("ProductService Constructor: context can not be null.");
            _context = context;
            _transactionService = new TransactionService();
        }

        public ProductService()
            : this(new IronBankEntities()) { }
            
        public Product GetById(Int32 id)
        {
            return _context.Products.Where((p) => p.Id == id).FirstOrDefault();
        }

        public IList<Product> GetByCustomer(Int32 id)
        {
            return _context.Products.Where((p) => p.CustomerId == id).ToList();
        }

        public Product Save(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void DeleteById(Int32 Id)
        {
            var toDelete = GetById(Id);
            if (null == toDelete)
                throw new ArgumentException("DeleteById : The provided Id does not represent any product.");
            Delete(toDelete);
        }
    }
}