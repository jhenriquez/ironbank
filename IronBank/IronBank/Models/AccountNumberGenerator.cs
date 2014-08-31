using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IronBank.Models
{
    public class AccountNumberGenerator
    {
        private Random generator = new Random((int)DateTime.Now.Ticks);

        public String Generate(int digits)
        {
            var account = "";

            do { account += generator.Next(50, 300).ToString(); } while (account.Length < digits);

            return account.Substring(0, digits);
        }

        public String Generate()
        {
            return Generate(10);
        }
    }
}