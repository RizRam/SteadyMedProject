using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileService.Models
{
    public class Profile
    {
        HashSet<Patient> _patients;

        public Profile()
        {
            _patients = new HashSet<Patient>();
        }

        public int UserID { get; set; }
        public string Name { get; set; }
        public HashSet<Patient> Patients { get { return _patients; } set { _patients = value; } }
    }
}
