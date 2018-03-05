using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SteadyMedApiGateway.Models.PatientModel;
using SteadyMedApiGateway.Models.PhysicianViewModels;
using SteadyMedApiGateway.Models.PatientMedicationPlan;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using System.Net.Http;

namespace SteadyMedApiGateway.Controllers
{
    public class PatientController : Controller
    {
        private readonly HttpClient _client;

        public PatientController(HttpClient client)
        {
            _client = client;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            PatientViewModel model = new PatientViewModel();

            //var currentUser = await _userManager.GetUserAsync(User) as Physician;

            Physician currentPhysician = new Physician();
            currentPhysician.ID = 3;
            currentPhysician.FirstName = "Doctor McDoctor";

            Patient temp = new Patient();

            temp.ID = 2;
            temp.FirstName = "Patient Patient";
            temp.SteadyMedsOwned.Add(4);
            temp.Plans.Add(new MedicationPlan
            {
                MedicationPlanId = 1,
                Patient = temp,
                PatientId = temp.ID,
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
            if (model == null) RedirectToAction("Index", "Physician");

            Debug.WriteLine("Model: " + model.NewMedPlan.MedicationPlanId);
            MedicationPlan plan = new MedicationPlan();
            //plan.PhysicianId = model.CurrentPhysician.ID;
            plan.PatientId = model.Patient.ID;
            //plan.Patient = model.Patient;
            plan.Medication = model.NewMedPlan.Medication;
            //plan.SteadyMedId = model.Patient.SteadyMedsOwned.FirstOrDefault();
            plan.HourlyInterval = model.NewMedPlan.HourlyInterval;
            plan.PillsPerInterval = model.NewMedPlan.PillsPerInterval;

            //Add plan to database/service



            return RedirectToAction("Details", new { id = model.Patient.ID });

        }
    }
}