using System;
using System.Collections.Generic;

namespace Sabs.AccountService.Models.Accounting
{
    /** 
     * Account's balance which is supposed to be closed monthly. 
     * Note the logic should not assume the account to be closed monthly.
     * Only that the account balance is either closed or not closed
     */
    public class Balance
    {
        public Account Account {get; set;}
        public DateTime CloseDate {get; set;}
        public int AccountBalance {get; set;}
    }
}
