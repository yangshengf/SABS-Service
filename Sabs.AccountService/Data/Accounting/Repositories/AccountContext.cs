using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sabs.AccountService.Data.Accounting.Models;
using Sabs.AccountService.Exceptions;

namespace Sabs.AccountService.Data.Accounting.Repositories
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
        public DbSet<Institution> Institutions {get; set;}
        public DbSet<Transaction> Transactions {get; set;}
        public DbSet<AccountType> AccountTypes {get; set;}
        public DbSet<Balance> Balances {get; set;}

        public Account FindAccountById(int id)
        {
            return Accounts.Find(id);
        }

        public IEnumerable<Institution> FindAllInstitutions()
        {
            return Institutions.ToList();
        }

        public Institution FindInstitutionById(int id)
        {
            return Institutions.Find(id);
        }

        public void InsertInstitution(Institution newInstitution)
        {
            Institutions.Add(newInstitution);
            SaveChanges();
        }

        public void UpdateInstitution(Institution institution)
        {
            Institution existingInstitution = Institutions.Find(institution.Id);
            existingInstitution.Name = institution.Name;
            Institutions.Update(existingInstitution);
            SaveChanges();
        }

        public void DeleteInstitution(Institution institution)
        {
            IEnumerable<Account> associatedAccounts = Accounts.Where(a=>a.FinancialInstitutionId == institution.Id).Include(a=>a.ClosedBalances).AsNoTracking().ToList();
            if(associatedAccounts.Count() > 0)
            {
                if(associatedAccounts.Any(a=>a.ClosedBalances.Count()>0))
                {
                    throw new DataRetentionException("Has associated accounts with closed balance which cannot be deleted");
                }
                else
                {
                    throw new DataRetentionException("Has associated accounts which needs to be deleted before institution can be deleted");
                }
            }
            else 
            {
                Institution existingInstitution = Institutions.Find(institution.Id);
                Institutions.Remove(existingInstitution);
            }
        }
    }
}
