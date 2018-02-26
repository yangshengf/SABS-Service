using System;
using System.Collections.Generic;

namespace Sabs.AccountService.Data.Accounting.Models
{
    public class Transaction
    {
        public int Id {get; set;}
        public DateTime TransactionDate {get; set;}
        public int AccountId {get; set;}
        public Account Account {get; set;}
        public int Amount {get; set;}
        public bool Closed {get; set;}
        public string Description {get; set;}
    }
}
