using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManagementService.Models
{
    public class Account
    {
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
        public HashSet<int> SteadyMedsOwned { get { return _steadyMedsOwned; } set { _steadyMedsOwned = value; }  }

    }
}
