using System;
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

            if (Source.AccountNumber == Target.AccountNumber)
                throw new InvalidOperationException("ExecuteTransference: You need to specify different accounts.");

            if (Amount <= 0)
                throw new InvalidOperationException("ExecuteTransference: You need to provide a balance that is greater than zero.");

            productsManager.DebitAccount(Source, Amount, "Transfer To: " + Target.AccountNumber);
            productsManager.CreditAccount(Target, Amount, "Transfer From: " + Source.AccountNumber);
            
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