using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountManagementService.Data;
using AccountManagementService.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace AccountManagementService.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly AccountCollection _collection;

        public AccountController(AccountCollection collection)
        {
            _collection = collection;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Account Get(int id)
        {
            return _collection.GetAccount(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Account value)
        {
            if (value == null) return BadRequest();

            if (!_collection.AddAccount(value)) return BadRequest();

            return CreatedAtRoute("/api/[controller]/", new { id = value.AccountId }, value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Account value)
        {
            if (value == null || value.AccountId != id) return BadRequest();

            Account account = _collection.GetAccount(id);
            if (account == null) return NotFound();

            account.AccountPrivilege = value.AccountPrivilege;
            account.Name = value.Name;
            account.PatientList = value.PatientList;
            account.SteadyMedsOwned = value.SteadyMedsOwned;


            return new NoContentResult();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id,[FromBody]JsonPatchDocument<Account> patch)
        {
            Account original = _collection.GetAccount(id);
            if (original == null) return BadRequest();

            patch.ApplyTo(original);

            return new ObjectResult(original); 
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _collection.RemoveAccount(id);
        }
    }
}
