using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sabs.AccountService.Models.Accounting
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts {get; set;}
        public DbSet<Institution> Institutions {get; set;}
        public DbSet<Transaction> Transactions {get; set;}
        public DbSet<AccountType> AccountTypes {get; set;}
        public DbSet<Balance> Balances {get; set;}

        public Account FindAccountById(int id)
        {
            return Accounts.Find(id);
        }
    }
}
