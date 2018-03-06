using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManagementService.Models
{

    //A model for account objects
    public class Account
    {
        //Types of accounts, these are flags, so that a physican can
        //also be a patient as well.
        public enum AccountType
        {
            patient = 1,
            caretaker = 2,
            physican = 4
        }

        private HashSet<int> _steadyMedsOwned;

       public Account()
        {
            _steadyMedsOwned = new HashSet<int>();
        }

        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public AccountType AccountPrivilege { get; set; }

        //The ids of indivicual SteadyMed canisters owned by Account owner.
        public HashSet<int> SteadyMedsOwned { get { return _steadyMedsOwned; } set { _steadyMedsOwned = value; }  }

    }
}
