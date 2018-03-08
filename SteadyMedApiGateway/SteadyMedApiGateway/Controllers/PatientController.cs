using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SteadyMedApiGateway.Models.PatientModel;
using SteadyMedApiGateway.Models.PhysicianViewModels;
using SteadyMedApiGateway.Models.PatientMedicationPlan;
using SteadyMedApiGateway.Controllers;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;
using SteadyMedApiGateway.Data;

/// <summary>
/// Author: Craig Rainey
/// Controller to connect the front-end with the microservices that put together the patient pages and its functionality.
/// </summary>
namespace SteadyMedApiGateway.Controllers
{
    public class PatientController : Controller
    {
        //HTTP Client
        private HttpClient _client;
        private MyUserManager _userManager;

        //Constructor
        public PatientController(HttpClient client, MyUserManager myUserManager)
        {
            _client = client;
            _userManager = myUserManager;
        }

        //Index page for the Patient
        public IActionResult Index()
        {
            return View();
        }

        //Details page for the patient. This will show the patient details along with a list of the medication plans they
        //currently have set up.
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Details(Patient patient)
        {

            PatientViewModel model = new PatientViewModel();

            //var currentUser = await _userManager.GetUserAsync(User) as Physician;

            Physician currentPhysician = new Physician();
            currentPhysician.ID = _userManager.User.AccountId;

            patient.Plans = new GatewayController().GetPatientMedicationPlans(patient.ID).Result;

            model.CurrentPhysician = currentPhysician;
            model.Patient = patient;
            model.NewMedPlan = new MedicationPlan();

            return View(model);
        }

        //Creates medication plans for the patient. These will be persisted and then send the physician back to the index
        //page.
        //KNOWN BUG: If the page leads back to the patient details page, then the medication plan will not show immediately.
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> CreateMedicationPlan(PatientViewModel model)
        {
            if (model == null) RedirectToAction("Index", "Physician");

            MedicationPlan plan = new MedicationPlan();
            plan.MedicationPlanId = 10;
            plan.PhysicianId = model.CurrentPhysician.ID;
            plan.PatientId = model.PatientId;
            plan.SteadyMedId = model.NewMedPlan.SteadyMedId;
            plan.Medication = model.NewMedPlan.Medication;
            plan.HourlyInterval = model.NewMedPlan.HourlyInterval;
            plan.PillsPerInterval = model.NewMedPlan.PillsPerInterval;
            plan.Completed = false;

            new GatewayController().CreateMedicationPlan(plan);

            return RedirectToAction("Details", "Physician", new { id = model.CurrentPhysician.ID});

        }
    }
}