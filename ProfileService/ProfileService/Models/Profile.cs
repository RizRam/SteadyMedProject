using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileService.Models
{
    public class Profile
    {
        HashSet<Account> _patients;

        public Profile()
        {
            _patients = new HashSet<Account>();
        }

        public int UserID { get; set; }
        public string Name { get; set; }
        public HashSet<Account> Patients { get { return _patients; } set { _patients = value; } }
    }
}
