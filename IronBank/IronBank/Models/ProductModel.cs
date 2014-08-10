using System;
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

        [NotMapped]
        public Double Balance { get; set; }

        [NotMapped]
        public Double AvailableBalance { get; set; }
    }

    public interface IProductService
    {
        bool Delete(Product product);
        IEnumerable<Product> GetByCustomer(Int32 id);
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
            return null;
        }

        public IEnumerable<Product> GetByCustomer(Int32 id)
        {
            return null;
        }

        public Product Save(Product product)
        {
            return product;
        }

        public bool Delete(Product product)
        {
            return false;
        }
    }
}