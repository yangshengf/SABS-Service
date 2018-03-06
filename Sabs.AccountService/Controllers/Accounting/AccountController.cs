using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sabs.AccountService.Controllers.Filters;
using Sabs.AccountService.Data.Accounting.Context;
using Sabs.AccountService.Data.Accounting.Models;
using Sabs.AccountService.Data.Accounting.Repositories;

namespace Sabs.AccountService.Controllers.Accounting
{
    [Route("api/[controller]")]
    [GenericExceptionFilter]
    public class AccountController : Controller
    {
        AccountRepository _accountRepository;

        public AccountController(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return _accountRepository.GetAccountList();
        }

        [HttpGet("{id}")]
        public Account Get(int id)
        {
            return _accountRepository.FindAccountById(id);
        }

        [HttpPost]
        public void Post([FromBody] Account account) 
        {
            _accountRepository.InsertAccount(account);
        }

        [HttpPost("{id}")]
        public void Post(int id, [FromBody] Account account)
        {
            account.Id = id;
            _accountRepository.UpdateAccountMetadata(account);
        }
    }
}
