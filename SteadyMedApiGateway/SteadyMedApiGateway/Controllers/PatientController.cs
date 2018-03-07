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
using Newtonsoft.Json;

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

        //Medication Plan microsevice URL
        private const string MEDICATION_PLAN_URL = "http://localhost:50151/api/MedPlans";

        //Patient Medication Plan microservice URL
        private const string PATIENT_PLANS_URL = "http://localhost:50151/api/PatientMedPlans";

        //Constructor
        public PatientController(HttpClient client)
        {
            _client = client;
        }

        //Index page for the Patient
        public IActionResult Index()
        {
            return View();
        }

        //Details page for the patient. This will show the patient details along with a list of the medication plans they
        //currently have set up.
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(Patient patient)
        {

            PatientViewModel model = new PatientViewModel();

            //var currentUser = await _userManager.GetUserAsync(User) as Physician;

            Physician currentPhysician = new Physician();
            currentPhysician.ID = 3;
            currentPhysician.FirstName = "Doctor McDoctor";

            HttpResponseMessage response = await _client.GetAsync(String.Format("{0}/{1}", PATIENT_PLANS_URL, patient.ID));
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                patient.Plans = JsonConvert.DeserializeObject<List<MedicationPlan>>(responseBody);
            }

            model.CurrentPhysician = currentPhysician;
            model.Patient = patient;
            model.NewMedPlan = new MedicationPlan();

            return View(model);
        }

        //Creates medication plans for the patient. These will be persisted and then send the physician back to the index
        //page.
        //KNOWN BUG: If the page leads back to the patient details page, then the medication plan will not show immediately.
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateMedicationPlan(PatientViewModel model)
        {
            if (model == null) RedirectToAction("Index", "Physician");

            MedicationPlan plan = new MedicationPlan();
            plan.MedicationPlanId = 10;
            plan.PhysicianId = model.PhysicianId;
            plan.PatientId = model.PatientId;
            plan.Medication = model.NewMedPlan.Medication;
            plan.HourlyInterval = model.NewMedPlan.HourlyInterval;
            plan.PillsPerInterval = model.NewMedPlan.PillsPerInterval;
            plan.Completed = false;

            var jsonRequest = JsonConvert.SerializeObject(plan);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonRequest);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var result = _client.PostAsync(MEDICATION_PLAN_URL, byteContent);

            return RedirectToAction("Index", "Physician");
        }
    }
}