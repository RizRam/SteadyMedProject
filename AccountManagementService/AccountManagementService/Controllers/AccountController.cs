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
    /// <summary>
    /// Controller that handles CRUD requests for Accounts.
    /// Normally each of these requests will require authorization/authentication
    /// to ensure security and privacy.
    /// </summary>
    [Route("api/[controller]/")]
    public class AccountController : Controller
    {
        private readonly AccountCollection _collection;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">Data source</param>
        public AccountController(AccountCollection collection)
        {
            _collection = collection;
        }

        /// <summary>
        /// GET request for all Accounts in the service
        /// This is for testing purposes only.  For security and privacy, this GET
        /// request will not exist in the actual service.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Account> Index()
        {
            return _collection.GetAll();
        }

        /// <summary>
        /// GET request for an Account object
        /// </summary>
        /// <param name="id">ID of desired Account</param>
        /// <returns>Desired Account</returns>        
        // GET api/values/5
        [HttpGet("{id}")]
        public Account Get(int id)
        {
            return _collection.GetAccount(id);
        }

        /// <summary>
        /// POST request to create and add an Account to the database
        /// </summary>
        /// <param name="value">Account object to add to database</param>
        /// <returns>URL of newly created Account</returns>
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Account value)
        {
            if (value == null) return BadRequest();

            if (!_collection.AddAccount(value)) return BadRequest();

            return CreatedAtRoute("/api/[controller]/", new { id = value.AccountId }, value);
        }
        
        /// <summary>
        /// PUT request to update an Account in the database
        /// </summary>
        /// <param name="id">ID of Account to update</param>
        /// <param name="value">Account object that contains values to update</param>
        /// <returns>NoContent result</returns>
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

        /// <summary>
        /// PATCH request to update an account using JasonPatch
        /// </summary>
        /// <param name="id">ID of Account to update</param>
        /// <param name="patch">JasonPatch document that provides update
        /// operations</param>
        /// <returns>Returns Accoutn object that was updated</returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id,[FromBody]JsonPatchDocument<Account> patch)
        {
            Account original = _collection.GetAccount(id);
            if (original == null) return BadRequest();

            patch.ApplyTo(original);

            return new ObjectResult(original); 
        }

        /// <summary>
        /// DELETE request for Account
        /// </summary>
        /// <param name="id">ID of Account to be deleted</param>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _collection.RemoveAccount(id);
        }
    }
}
