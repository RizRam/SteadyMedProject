using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountManagementService.Models;
using AccountManagementService.Data;

namespace AccountManagementService.Controllers
{
    [Route("/api/[Controller]")]
    public class LoginController : Controller
    {
        private readonly AccountCollection _collection;
        
        public LoginController(AccountCollection collection)
        {
            _collection = collection;
        }

        [HttpGet]
        public IActionResult Login([FromBody] string userName, string password)
        {
            if (userName == null || password == null) return BadRequest();

            Account account = _collection.GetAccountByUserName(userName);
            if (account == null || account.Password != password)
            {
                ModelState.AddModelError("400", "Incorrect Login");
                return BadRequest(ModelState);
            }

            return new ObjectResult(account);
        }

    }
}