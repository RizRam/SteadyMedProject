using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteadyMedApiGateway.Models.PatientModel;

/// <summary>
/// Author: Craig Rainey
/// Model for a medication plan. This encapsulates all of the information necessary to setup an up-to-date
/// schedule on a steadymed device.
/// </summary>
namespace SteadyMedApiGateway.Models.PatientMedicationPlan
{
    public class MedicationPlan
    {
        //Medication Plan ID
        public int MedicationPlanId { get; set; }

        //Patient this medication plan is associated with
        public Patient Patient { get; set; }

        //Patient ID
        public int PatientId { get; set; }

        //Physician ID
        public int PhysicianId { get; set; }

        //SteadyMed Device ID
        public int SteadyMedId { get; set; }

        //Type of medication being administered
        public string Medication { get; set; }

        //Hours between dose administrations
        public int HourlyInterval { get; set; }

        //Pills to take per dose
        public int PillsPerInterval { get; set; }

        //True or false value to indicate if a perspcription has been completed
        public bool Completed { get; set; }
    }
}
