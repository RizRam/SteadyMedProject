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
    public class MedPlansController : Controller
    {
        private MedicationPlanCollection _plans;

        public MedPlansController(MedicationPlanCollection plans)
        {
            _plans = plans;
        }

        // GET api/MedPlans
        [HttpGet]
        public IEnumerable<MedicationPlan> Get()
        {
            //return new string[] { "value1", "value2" };
            return _plans.GetAllPlans();
            
        }

        // GET api/MedPlans/5
        [HttpGet("{id}", Name = "GetPlan")]
        public IActionResult Get(int id)
        {
            var result = _plans.GetPlan(id);
            if (result == null) return NotFound();

            return new ObjectResult(result);
        }


        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]MedicationPlan plan)
        {
            if (plan == null) return BadRequest();

            if (!_plans.AddPlan(plan)) return BadRequest();

            return CreatedAtRoute("GetPlan", new { id = plan.MedicationPlanId }, plan);
        }

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

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _plans.DeletePlan(id);

            return new NoContentResult();
        }
    }
}
