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

        public string CustomerId { get; set; }

        public string AccountNumber { get; set; }

        public virtual User Customer { get; set; }

        public Double Balance { get; set; }

        [NotMapped]
        public Double AvailableBalance { get; set; }
    }

    public interface IProductService
    {
        void Delete(Product product);
        void DeleteById(Int32 id);
        IList<Product> GetByCustomer(String id);
        Product GetById(Int32 id);
        Product Save(Product product);
        Product Create(String customerId, ProductType type, ProductCurrency currency, Double balance);
        Product Create(User customer, ProductType type, ProductCurrency currency, Double balance);
    }

    public class ProductService : IProductService
    {
        private IronBankEntities _context;
        private ITransactionService _transactionService;
        private AccountNumberGenerator generator = new AccountNumberGenerator();

        public ProductService(IronBankEntities context)
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

        public IList<Product> GetByCustomer(String id)
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

        public Product Create(String customerId, ProductType type, ProductCurrency currency, Double balance)
        {
            if (String.IsNullOrEmpty(customerId)) throw new ArgumentNullException("Create: customerId can not be null or empty.");
            if (Double.IsNaN(balance)) throw new ArgumentNullException("Create: balance should be a valid number.");
            if (Double.IsNaN(balance)) throw new ArgumentNullException("Create: balance should be a valid number.");
            if (balance <= 0) throw new InvalidOperationException("Create: balance should be a positive number greater than zero.");

            var product = new Product() { CustomerId = customerId, Balance = balance, Currency = currency, Type = type, AccountNumber = generator.Generate() };
            _context.Transactions.Add(new Transaction() { Amount = balance, CreatedAt = DateTime.Now, Product = product, Status = TransactionStatus.Completed, Type = TransactionType.Credit, Number = generator.Generate(15), Description = "Opening Balance Deposit" });
            return Save(product);
        }

        public Product Create(User customer, ProductType type, ProductCurrency currency, Double balance)
        {
            return Create(customer.Id, type, currency, balance);
        }

        public Product GetByNumber(String number)
        {
            if (string.IsNullOrEmpty(number)) throw new ArgumentNullException("GetByNumber: number can not be null or empty.");
            return _context.Products.Where((p) => p.AccountNumber == number).FirstOrDefault();
        }
    }
}