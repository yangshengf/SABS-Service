using System;
using System.Collections.Generic;

namespace Sabs.AccountService.Data.Accounting.Models
{
    /** 
     * Account's balance which is supposed to be closed monthly. 
     * Note the logic should not assume the account to be closed monthly.
     * Only that the account balance is either closed or not closed
     */
    public class Balance
    {
        /** Key is configured in Fluent API */
        public int AccountId {get; set;}
        public Account Account {get; set;}
        public DateTime CloseDate {get; set;}
        public int AccountBalance {get; set;}
    }
}
