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

namespace SteadyMedApiGateway.Controllers
{
    public class PatientController : Controller
    {
        private HttpClient _client;

        private const string MEDICATION_PLAN_URL = "http://localhost:50151/api/MedPlans";
        private const string PATIENT_PLANS_URL = "http://localhost:50151/api/PatientMedPlans";

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

        [HttpPost]
        public async Task<IActionResult> CreateMedicationPlan(PatientViewModel model)
        {
            if (model == null) RedirectToAction("Index", "Physician");

            MedicationPlan plan = new MedicationPlan();
            plan.MedicationPlanId = 10;
            plan.PhysicianId = model.PhysicianId;
            plan.PatientId = model.PatientId;
            //plan.Patient = model.Patient;
            plan.Medication = model.NewMedPlan.Medication;
            //plan.SteadyMedId = model.Patient.SteadyMedsOwned.FirstOrDefault();
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