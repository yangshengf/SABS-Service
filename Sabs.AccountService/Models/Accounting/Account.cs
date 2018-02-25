using System;
using System.Collections.Generic;

namespace Sabs.AccountService.Models.Accounting
{
    public class Account
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public Institution Servicer {get; set;}
        public AccountType Type {get; set;}
        public DateTime OpenDate {get; set;}
        public DateTime CloseDate {get; set;}
    }
}
