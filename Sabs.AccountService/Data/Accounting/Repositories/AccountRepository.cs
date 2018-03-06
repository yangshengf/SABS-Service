using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sabs.AccountService.Data.Accounting.Context;
using Sabs.AccountService.Data.Accounting.Models;
using Sabs.AccountService.Exceptions;

namespace Sabs.AccountService.Data.Accounting.Repositories
{
    public class AccountRepository
    {
        private AccountContext _context;

        public AccountRepository(AccountContext context)
        {
            _context = context;
        }

        public Account FindAccountById(int id)
        {
            return _context.Accounts.Find(id);
        }

        public IEnumerable<Account> GetAccountList()
        {
            return _context.Accounts.ToList();
        }

        public void InsertAccount(Account newAccount)
        {
            _context.Accounts.Add(newAccount);
            _context.SaveChanges();
        }

        public void UpdateAccountMetadata(Account account)
        {
            Account existingAccount = _context.Accounts.Find(account.Id);
            existingAccount.NickName = account.NickName;
            existingAccount.InstitutionName = account.InstitutionName;
            _context.Update(existingAccount);
            _context.SaveChanges();
        }

        public void DeleteAccount(Account account)
        {
            bool hasClosedBalance = _context.Accounts.Where(a=>a.Id==account.Id).Select(a=>a.ClosedBalances).Any();
            if(hasClosedBalance)
            {
                throw new DataRetentionException("Account has closed balance and cannot be deleted");
            }
            else 
            {
                Account existingAccount = _context.Accounts.Find(account.Id);
                _context.Accounts.Remove(existingAccount);
                _context.SaveChanges();
            }
        }

        public void CloseAccount(Account account, DateTime closeDate)
        {
            bool hasClosedBalance = _context.Accounts.Where(a=>a.Id==account.Id).Select(a=>a.ClosedBalances).Any();
            if(hasClosedBalance)
            {
                Account existingAccount = _context.Accounts.Find(account.Id);
                existingAccount.CloseDate = closeDate;
                _context.Update(existingAccount);
                _context.SaveChanges();
            }
            else 
            {
                throw new DataRetentionException("Account cannot be closed without balance posted");
            }
        }
    }
}
