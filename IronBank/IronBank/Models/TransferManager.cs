﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronBank.Models
{
    public class TransferManager
    {
        protected IronBankEntities db;
        protected ProductService productsManager;
        protected TransactionService transactionManager;

        public TransferManager() : this(new IronBankEntities()) { }

        public TransferManager(IronBankEntities context)
        {
            if (context == null)
                throw new ArgumentNullException("TransferManager: context can not be null.");
            db = context;
            productsManager = new ProductService(db);
            transactionManager = new TransactionService(db);
        }

        public Product Source { get; private set; }
        public Product Target { get; private set; }
        public Double Amount { get; set; }


        public void ExecuteTransference()
        {
            if (Source == null || Target == null)
                throw new InvalidOperationException("ExecuteTransference: You need to provide a source and a target account.");

            if (Source.Balance < Amount)
                throw new InvalidOperationException("ExecuteTransference: The provided amount exceeds the source account.");

            Source.Balance -= Amount;
            Target.Balance += Amount;


            db.Transactions.Add(
                transactionManager.Create(Source, TransactionType.Debit, Amount)
                );

            db.Transactions.Add(
                transactionManager.Create(Target, TransactionType.Debit, Amount)
                );

            db.Entry(Source).State = System.Data.Entity.EntityState.Modified;
            db.Entry(Target).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
        }

        public void SetSource(String accountNumber)
        {
            Source = productsManager.GetByNumber(accountNumber);
        }

        public void SetTarget(String accountNumber)
        {
            Target = productsManager.GetByNumber(accountNumber);
        }
    }
}