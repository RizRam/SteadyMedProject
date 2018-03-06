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
    /// Controller to handle verification requests.
    /// In the actual implementation, this may be handled by the cloud's OAuth service
    /// </summary>
    [Route("/api/[controller]/")]
    public class VerificationController : Controller
    {
        private readonly AccountCollection _collection;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">Data source</param>
        public VerificationController(AccountCollection collection)
        {
            _collection = collection;
        }


        /// <summary>
        /// Verifies whether account exists and whether it has the access level it claims
        /// </summary>
        /// <param name="id">ID of Account to verify</param>
        /// <param name="privilege">Privilege level of account to verify</param>
        /// <returns>True if account has that level of privilege, false otherwise</returns>
        [HttpGet]
        public bool VerifyAccount(int id, int privilege)
        {
            Account account = _collection.GetAccount(id);
            if (account == null) return false;

            if (!account.AccountPrivilege.HasFlag((Account.AccountType)privilege))
            {
                return false;
            }

            return true;
        }

    }
}