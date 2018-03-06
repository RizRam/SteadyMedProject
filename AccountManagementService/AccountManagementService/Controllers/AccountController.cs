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
    //Controller that handles requests for Accounts.  Normally each of these requests
    //will require authorization to ensure security and privacy

    [Route("api/[controller]/")]
    public class AccountController : Controller
    {
        private readonly AccountCollection _collection;

        //Constructor
        public AccountController(AccountCollection collection)
        {
            _collection = collection;
        }


        //Currently the Index for this controller returns all accounts tracked by the service
        //This is for testing purposes.  For security and privacy, this GET will not exist in the actual service.
        [HttpGet]
        public IEnumerable<Account> Index()
        {
            return _collection.GetAll();
        }


        //Request for an Account using id
        // GET api/values/5
        [HttpGet("{id}")]
        public Account Get(int id)
        {
            return _collection.GetAccount(id);
        }

        //POST a new account
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Account value)
        {
            if (value == null) return BadRequest();

            if (!_collection.AddAccount(value)) return BadRequest();

            return CreatedAtRoute("/api/[controller]/", new { id = value.AccountId }, value);
        }
        
        //Update an account given id
        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Account value)
        {
            if (value == null || value.AccountId != id) return BadRequest();

            Account account = _collection.GetAccount(id);
            if (account == null) return NotFound();

            account.UserName = value.UserName;
            account.AccountId = value.AccountId;
            account.Password = value.Password;
            account.AccountPrivilege = value.AccountPrivilege;
            account.Name = value.Name;
            account.SteadyMedsOwned = value.SteadyMedsOwned;


            return new NoContentResult();
        }

        //Update an account using a JsonPatch document
        [HttpPatch("{id}")]
        public IActionResult Patch(int id,[FromBody]JsonPatchDocument<Account> patch)
        {
            Account original = _collection.GetAccount(id);
            if (original == null) return BadRequest();

            patch.ApplyTo(original);

            return new ObjectResult(original); 
        }

        //Delete an Account
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _collection.RemoveAccount(id);
        }
    }
}
