using System;
using System.Collections.Generic;
using System.Text;

namespace SteadyMedDevice
{
    class MedicationPlan
    {
        public int MedicationPlanId { get; set; }
        public int PatientId { get; set; }
        public int PhysicianId { get; set; }
        public int SteadyMedId { get; set; }
        public string Medication { get; set; }
        public int HourlyInterval { get; set; }
        public int PillsPerInterval { get; set; }
        public bool Completed { get; set; }
    }
}
