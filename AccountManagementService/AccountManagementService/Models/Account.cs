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
            patient,
            caretaker,
            physican
        }

        private HashSet<int> _steadyMedsOwned;
        private HashSet<int> _patientList;

       public Account()
        {
            _steadyMedsOwned = new HashSet<int>();
            _patientList = new HashSet<int>();
        }

        public int AccountId { get; set; }
        public string Name { get; set; }
        public AccountType AccountPrivilege { get; set; }
        public HashSet<int> SteadyMedsOwned { get { return _steadyMedsOwned; } set { _steadyMedsOwned = value; }  }
        public HashSet<int> PatientList { get { return _patientList; } set { _patientList = value; } }

    }
}
