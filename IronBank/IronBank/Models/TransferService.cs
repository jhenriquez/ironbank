using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronBank.Models
{
    public class TransferManager
    {
        protected IronBankEntities db;

        public TransferManager() : this(new IronBankEntities()) { }

        public TransferManager(IronBankEntities context)
        {
            if (context == null)
                throw new ArgumentNullException("TransferManager: context can not be null.");
        }

        public Product Source { get; private set; }
        public Product Target { get; private set; }
        public Double Amount { get; private set; }
        public void ExecuteTransference()
        {
            // Validate Amount Availability
            // Create Transactions
            // Apply Amount 
            //  Save Changes
        }
    }
}