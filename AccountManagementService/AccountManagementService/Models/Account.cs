using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManagementService.Models
{

    /// <summary>
    /// Model for accounts
    /// </summary>
    public class Account
    {
        /// <summary>
        /// A flag for types of accounts: Patients, Caretakers, Physicians
        /// </summary>
        public enum AccountType
        {
            patient = 1,
            caretaker = 2,
            physican = 4
        }

       private HashSet<int> _steadyMedsOwned;
        
        /// <summary>
        /// Constructor
        /// </summary>
       public Account()
        {
            _steadyMedsOwned = new HashSet<int>();
        }

        //ID of account
        public int AccountId { get; set; }
        //UserName of account
        public string UserName { get; set; }
        //Accoutn password
        public string Password { get; set; }
        //Name of account owner
        public string Name { get; set; }
        //Flags of account type/privilege
        public AccountType AccountPrivilege { get; set; }

        //The ids of individual SteadyMed canisters owned by Account owner.
        public HashSet<int> SteadyMedsOwned { get { return _steadyMedsOwned; } set { _steadyMedsOwned = value; }  }

    }
}
