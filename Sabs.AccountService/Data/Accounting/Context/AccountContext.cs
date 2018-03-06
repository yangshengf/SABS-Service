using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sabs.AccountService.Data.Accounting.Models;
using Sabs.AccountService.Exceptions;

namespace Sabs.AccountService.Data.Accounting.Context
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Balance>().HasKey(b => new { b.AccountId, b.CloseDate });
        }

        public DbSet<Account> Accounts {get; set;}
        public DbSet<Transaction> Transactions {get; set;}
        public DbSet<AccountType> AccountTypes {get; set;}
        public DbSet<Balance> Balances {get; set;}
    }
}
