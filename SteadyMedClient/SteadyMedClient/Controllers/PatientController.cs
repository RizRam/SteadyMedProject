using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SteadyMedClient.Models;
using Microsoft.AspNetCore.Identity;

namespace SteadyMedClient.Controllers
{
    public class PatientController : Controller
    {
        /*
        private readonly UserManager<User> _userManager;

        public PatientController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        */

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            PatientViewModel model = new PatientViewModel();

            //var currentUser = await _userManager.GetUserAsync(User) as Physician;

            Physician currentPhysician = new Physician();
            currentPhysician.UserId = 3;
            currentPhysician.Name = "Doctor McDoctor";
            
            Patient temp = new Patient();

            temp.UserId = 2;
            temp.Name = "Patient Patient";
            temp.SteadyMedsOwned.Add(4);
            temp.Plans.Add(new MedicationPlan
            {
                MedicationPlanId = 1,
                Patient = temp,
                PatientId = temp.UserId,
                PhysicianId = 5,
                SteadyMedId = 4,
                Medication = "Crack",
                HourlyInterval = 6,
                PillsPerInterval = 2,
                Completed = false
            });

            model.CurrentPhysician = currentPhysician;
            model.Patient = temp;
            model.NewMedPlan = new MedicationPlan();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicationPlan(PatientViewModel model)
        {
            if (model == null) return View(model);

            MedicationPlan plan = new MedicationPlan();
            plan.PhysicianId = model.CurrentPhysician.UserId;
            plan.PatientId = model.Patient.UserId;
            plan.Patient = model.Patient;
            plan.Medication = model.NewMedPlan.Medication;
            plan.SteadyMedId = model.Patient.SteadyMedsOwned.FirstOrDefault();
            plan.HourlyInterval = model.NewMedPlan.HourlyInterval;
            plan.PillsPerInterval = model.NewMedPlan.PillsPerInterval;

            //Add plan to database/service

            

            return RedirectToAction("Details", new { id = model.Patient.UserId });

        }

    }
}