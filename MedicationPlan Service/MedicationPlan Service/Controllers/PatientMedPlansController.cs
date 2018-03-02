using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MedicationPlan_Service.Data;
using MedicationPlan_Service.Models;

namespace MedicationPlan_Service.Controllers
{
    [Route("api/[controller]")]
    public class PatientMedPlansController : Controller
    {
        MedicationPlanCollection _plans;

        public PatientMedPlansController(MedicationPlanCollection plans)
        {
            _plans = plans;
        }
        
        //Get a list of all medications plans under a patient
        //[HttpGet("{patientId}", Name = "GetPatientPlans")]
        [HttpGet("{patientId}")]
        public IEnumerable<MedicationPlan> GetPatientPlans(int patientId)
        {
            var result = _plans.GetPatientPlans(patientId);

            return result;
        }
    }
}