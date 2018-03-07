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
    /// Controller used for SteadyMed devices to request their
    /// assigned Medication Plans.
    /// </summary>
    [Route("api/[controller]")]
    public class SteadyMedPlansController : Controller
    {
        //Abstract data type that holds MedicationPlan objects in memory
        //In an actual implementation this might just be a reference to
        //a database.
        MedicationPlanCollection _plans;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="plans">Reference to ojbect that stores MedicationPlans</param>
        public SteadyMedPlansController(MedicationPlanCollection plans)
        {
            _plans = plans;
        }

        /// <summary>
        /// Get the most recent uncompleted MedicationPlan of a user's SteadyMed device  
        /// </summary>
        /// <param name="steadyMedId">ID of SteadyMed device</param>
        /// <returns>Requested medication plan</returns>
        [HttpGet("{steadyMedId}")]
        public MedicationPlan GetPatientPlans(int steadyMedId)
        {
            var result = _plans.GetSteadyMedPlan(steadyMedId);            

            return result;
        }
    }
}