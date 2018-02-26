using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sabs.AccountService.Controllers.Filters;
using Sabs.AccountService.Data.Accounting.Models;
using Sabs.AccountService.Data.Accounting.Repositories;

namespace Sabs.AccountService.Controllers.Accounting
{
    [Route("api/[controller]")]
    [GenericExceptionFilter]
    public class InstitutionController : Controller
    {
        AccountContext _context;

        public InstitutionController(AccountContext accountContext)
        {
            _context = accountContext;
        }

        [HttpGet]
        public IEnumerable<Institution> Get()
        {
            return _context.FindAllInstitutions();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Institution institution = _context.FindInstitutionById(id);
            if(institution!=null)
            {
                return Json(institution);
            }
            else 
            {
                return NotFound(new {message = "Not Found"});
            }
        }

        [HttpPost]
        public void Post([FromBody] Institution institution)
        {
            _context.InsertInstitution(institution);
        }

        [HttpPost("{id}")]
        public void Post(int id, [FromBody] Institution institution)
        {
            institution.Id = id;
            _context.UpdateInstitution(institution);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Institution toDelete = new Institution() {Id = id};
            _context.DeleteInstitution(toDelete);
        }
    }
}
