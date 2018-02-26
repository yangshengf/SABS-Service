using System;
using System.Collections.Generic;

namespace Sabs.AccountService.Data.Accounting.Models
{
    public class Account
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public int FinancialInstitutionId {get; set;}
        public Institution FinancialInstitution {get; set;}
        public int TypeId {get; set;}
        public AccountType Type {get; set;}
        public DateTime OpenDate {get; set;}
        public DateTime CloseDate {get; set;}

        /** Complex Types */
        public IEnumerable<Balance> ClosedBalances {get; set;}
        public IEnumerable<Transaction> AllTransactions {get; set;}
    }
}
