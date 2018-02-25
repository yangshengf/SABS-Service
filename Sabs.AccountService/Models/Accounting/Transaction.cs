using System;
using System.Collections.Generic;

namespace Sabs.AccountService.Models.Accounting
{
    public class Transaction
    {
        public DateTime TransactionDate {get; set;}
        public Account Account {get; set;}
        public int Amount {get; set;}
        public bool Closed {get; set;}
    }
}
