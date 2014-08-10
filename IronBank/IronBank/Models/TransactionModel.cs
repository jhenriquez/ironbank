using System;
using System.Collections.Generic;

namespace IronBank.Models
{
    public enum TransactionType
    {
        Credit,
        Debit
    }

    public enum TransactionStatus
    {
        Completed,
        InTransit
    }

    public class Transaction
    {
        public Int32 TransactionId { get; set; }
        public Int32 ProductId { get; set; }
        public TransactionType Type { get; set; }
        public TransactionStatus Status { get; set; }
        public Double Amount { get; set; }
    }


    public interface ITransactionService
    {
    }

    public class TransactionService : ITransactionService
    {
        public IEnumerable<Transaction> GetByType(TransactionType type)
        {
            return null;
        }

        public IEnumerable<Transaction> GetByProductId(Int32 id)
        {
            return null;
        }

        public IEnumerable<Transaction> GetByProduct(Product product)
        {
            return GetByProductId(product.Id);
        }

        public IEnumerable<Transaction> GetByProductIdAndDate(Int32 id, DateTime? start, DateTime? end)
        {
            return null;
        }

        public IEnumerable<Transaction> GetByProductAndDate(Product product, DateTime? start, DateTime? end)
        {
            return GetByProductIdAndDate(product.Id, start, end);
        }
    }
}