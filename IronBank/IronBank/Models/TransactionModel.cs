﻿using System;
using System.Linq;
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
        public virtual Product Product { get; set; }
        public TransactionType Type { get; set; }
        public TransactionStatus Status { get; set; }
        public Double Amount { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public interface ITransactionService
    {
        System.Collections.Generic.IList<Transaction> GetByProduct(Product product);
        System.Collections.Generic.IList<Transaction> GetByProductAndDate(Product product, DateTime? start, DateTime? end);
        System.Collections.Generic.IList<Transaction> GetByProductId(int id);
        System.Collections.Generic.IList<Transaction> GetByProductIdAndDate(int id, DateTime? start, DateTime? end);
        System.Collections.Generic.IList<Transaction> GetByType(TransactionType type);
    }


    public class TransactionService : IronBank.Models.ITransactionService
    {
        IronBankEntities context;

        private TransactionService(IronBankEntities providedContext)
        {
            this.context = providedContext;
        }

        public TransactionService() 
            : this(new IronBankEntities()) { }

        public IList<Transaction> GetByType(TransactionType type)
        {
            return context.Transactions.Where((t) => t.Type == type).ToList();
        }

        public IList<Transaction> GetByProductId(Int32 id)
        {
            return context.Transactions.Where((t) => t.ProductId == id).ToList();
        }

        public IList<Transaction> GetByProduct(Product product)
        {
            return GetByProductId(product.Id);
        }

        public IList<Transaction> GetByProductIdAndDate(Int32 id, DateTime? start, DateTime? end)
        {
            if (!start.HasValue && !end.HasValue)
                return GetByProductId(id);
            
            if (start.HasValue && !end.HasValue)
                return context.Transactions.Where((t) => t.ProductId == id && t.CreatedAt >= start.Value).ToList();
            
            if (!start.HasValue && end.HasValue)
                return context.Transactions.Where((t) => t.ProductId == id && t.CreatedAt <= end.Value).ToList();

            return context.Transactions
                .Where((t) => t.ProductId == id
                    && t.CreatedAt <= end.Value
                    && t.CreatedAt >= start.Value
                    ).ToList();
        }

        public IList<Transaction> GetByProductAndDate(Product product, DateTime? start, DateTime? end)
        {
            return GetByProductIdAndDate(product.Id, start, end);
        }
    }
}