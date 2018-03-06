using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sabs.AccountService.Data.Accounting.Context;
using Sabs.AccountService.Data.Accounting.Models;
using Sabs.AccountService.Exceptions;

namespace Sabs.AccountService.Data.Accounting.Repositories
{
    public class BalanceRepository
    {
        private AccountContext _context;

        public BalanceRepository(AccountContext context)
        {
            _context = context;
        }
    }
}
