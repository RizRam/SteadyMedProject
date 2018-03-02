using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileService.Models
{
    public class Profile
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public HashSet<int> SteadyMedsOwned { get; set; }
        public HashSet<int> Patients { get; set; }
    }
}
