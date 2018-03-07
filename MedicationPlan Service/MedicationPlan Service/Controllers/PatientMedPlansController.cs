using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MedicationPlan_Service.Data;
using MedicationPlan_Service.Models;

namespace MedicationPlan_Service.Controllers
{
    /// <summary>
    /// A Controller that handles requests of a Patient account's
    /// for Medication Plans.
    /// </summary>
    [Route("api/[controller]")]
    public class PatientMedPlansController : Controller
    {
        /// <summary>
        /// Abstract data type that stores all Medication Plan objects in memory.
        /// In an actual implementation, this may just be a reference an object that
        /// handles database requests.
        /// </summary>
        MedicationPlanCollection _plans;

        /// <summary>
        /// Controller
        /// </summary>
        /// <param name="plans">Data source</param>
        public PatientMedPlansController(MedicationPlanCollection plans)
        {
            _plans = plans;
        }

        /// <summary>
        /// Get a list of all medications plans under a patient
        /// </summary>
        /// <param name="patientId">ID of patient account</param>
        /// <returns>A collection of Medication Plans</returns>
        //[HttpGet("{patientId}", Name = "GetPatientPlans")]
        [HttpGet("{patientId}")]
        public IEnumerable<MedicationPlan> GetPatientPlans(int patientId)
        {
            var result = _plans.GetPatientPlans(patientId);

            return result;
        }
    }
}