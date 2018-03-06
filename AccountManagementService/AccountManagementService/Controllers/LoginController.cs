using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountManagementService.Models;
using AccountManagementService.Data;

namespace AccountManagementService.Controllers
{
    //Controller used to handle Login requests
    //This service may be integrated with the cloud
    //OAuth service and may not be needed, but this would depend
    //on how we trust the security of the cloud service to handle
    //private account information.
    [Route("/api/[Controller]")]
    public class LoginController : Controller
    {
        private readonly AccountCollection _collection;
        
        public LoginController(AccountCollection collection)
        {
            _collection = collection;
        }


        //
        [HttpGet]
        public IActionResult Login(string userName, string password)
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