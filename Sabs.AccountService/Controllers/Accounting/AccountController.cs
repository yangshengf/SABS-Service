using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sabs.AccountService.Data.Accounting.Models;
using Sabs.AccountService.Data.Accounting.Repositories;

namespace Sabs.AccountService.Controllers.Accounting
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        AccountContext _context;

        public AccountController(AccountContext accountContext)
        {
            _context = accountContext;
        }

        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return _context.Accounts.ToList();
        }

        [HttpGet("{id}")]
        public Account Get(int id)
        {
            return _context.FindAccountById(id);
        }

        [HttpPost]
        public void Post() {

        }
    }
}
