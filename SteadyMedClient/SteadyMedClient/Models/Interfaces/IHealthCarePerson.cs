using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteadyMedClient.Models
{
    interface IHealthCarePerson
    {
        HashSet<Patient> Patients { get; set; }
    }
}
