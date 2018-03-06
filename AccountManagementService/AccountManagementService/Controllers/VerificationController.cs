using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountManagementService.Models;
using AccountManagementService.Data;

namespace AccountManagementService.Controllers
{
    //Controller to handle verification requests
    //In an actual implementation, this will be handled by the cloud's OAuth Service
    [Route("/api/[controller]/")]
    public class VerificationController : Controller
    {

        private readonly AccountCollection _collection;

        //Construcctor
        public VerificationController(AccountCollection collection)
        {
            _collection = collection;
        }


        //Verifies whether account exists and whether it has the access level it claims
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