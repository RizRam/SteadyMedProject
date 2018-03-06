using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MedicationPlan_Service.Data;
using MedicationPlan_Service.Models;
using System.Diagnostics;

namespace MedicationPlan_Service.Controllers
{

    /// <summary>
    /// //Controller used to handle MedicationPlan CRUD requests
    /// </summary>
    [Route("api/[controller]")]
    public class MedPlansController : Controller
    {
        //Abstract data type used to hold MedicationPlan objects in memory.
        //In an actual implementation this may be just a reference to the database.
        private MedicationPlanCollection _plans;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="plans">Data source</param>
        public MedPlansController(MedicationPlanCollection plans)
        {
            _plans = plans;
        }

 
        /// <summary>
        /// GET request to obtain all medication plans (used for testing)
        /// This method will not exist in a Product environment for privacy and security.
        /// </summary>
        /// <returns>A collection of all Medication Plans</returns>
        // GET api/MedPlans
        [HttpGet]
        public IEnumerable<MedicationPlan> Get()
        {
            return _plans.GetAllPlans();
            
        }

        /// <summary>
        /// GET request to obtain a MedicationPlan object.  In an actual implementation
        /// this request will be authenticated before it is completed.
        /// </summary>
        /// <param name="id">Id of Medication Plan</param>
        /// <returns></returns>
        // GET api/MedPlans/5
        [HttpGet("{id}", Name = "GetPlan")]
        public IActionResult Get(int id)
        {
            var result = _plans.GetPlan(id);
            if (result == null) return NotFound();

            return new ObjectResult(result);
        }

        /// <summary>
        /// POST request to add a Medication Plan to the database
        /// </summary>
        /// <param name="plan">MedicationPlan object to addd</param>
        /// <returns>A URL to the MedicationPlan object created</returns>
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]MedicationPlan plan)
        {
            if (plan == null) return BadRequest();

            if (!_plans.AddPlan(plan)) return BadRequest();

            return CreatedAtRoute("GetPlan", new { id = plan.MedicationPlanId }, plan);
        }

        /// <summary>
        /// PUT request to update a Medication Plan
        /// </summary>
        /// <param name="id">ID of the Medication Plan to update</param>
        /// <param name="value">MedicationPlan update object</param>
        /// <returns>Server status notifications</returns>
        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]MedicationPlan value)
        {
            //Check for bad request
            if (value == null || value.MedicationPlanId != id) return BadRequest();

            //Get plan from collection
            MedicationPlan plan = _plans.GetPlan(id);
            if (plan == null) return NotFound();

            //Update values 
            plan.PatientId = value.PatientId;
            plan.PhysicianId = value.PhysicianId;
            plan.SteadyMedId = value.SteadyMedId;
            plan.HourlyInterval = value.HourlyInterval;            
            plan.PillsPerInterval = value.PillsPerInterval;
            plan.Completed = value.Completed;            

            return new NoContentResult();
        }

        /// <summary>
        /// DELETE request for a Medication Plan
        /// </summary>
        /// <param name="id">ID of Medication Plan to delete</param>
        /// <returns>A NoContent URL</returns>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _plans.DeletePlan(id);

            return new NoContentResult();
        }
    }
}
