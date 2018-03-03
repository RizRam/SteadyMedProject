using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteadyMedClient.Models
{
    public class PatientViewModel
    {
        public Patient Patient { get; set; }
        public MedicationPlan NewMedPlan {get; set;}

    }
}
