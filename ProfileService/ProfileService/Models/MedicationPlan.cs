using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteadyMedClient.Models
{
    public class MedicationPlan
    {
        public int MedicationPlanId { get; set; }
        public int PatientId { get; set; }
        public User Patient { get; set; }
        public int PhysicianId { get; set; }
        public int SteadyMedId { get; set; }
        public string Medication { get; set; }
        public int HourlyInterval { get; set; }
        public int PillsPerInterval { get; set; }
        public Boolean Completed { get; set; }
    }
}
