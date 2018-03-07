using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountManagementService.Models;
using AccountManagementService.Data;

namespace AccountManagementService.Controllers
{

    /// <summary>
    /// Controller used to handle login requests.
    /// This service may be integrated with the cloud OAuth service,
    /// and may not be needed.  This would depend on how we trust the
    /// security of the cloud service to handle private account information.
    /// </summary>
    [Route("/api/[Controller]")]
    public class LoginController : Controller
    {
        private readonly AccountCollection _collection;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">Data source</param>
        public LoginController(AccountCollection collection)
        {
            _collection = collection;
        }


        /// <summary>
        /// GET request to verify login details.
        /// </summary>
        /// <param name="userName">Username of account</param>
        /// <param name="password">Password of account</param>
        /// <returns>Server status.  If successful, returns the Account</returns>
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