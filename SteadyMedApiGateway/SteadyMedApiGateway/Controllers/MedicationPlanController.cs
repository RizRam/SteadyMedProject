using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using SteadyMedApiGateway.Models.PatientMedicationPlan;
using System.Diagnostics;

/// <summary>
/// Author: Craig Rainey
/// Controller to link the front-end services with the Medication Plan microservice This will retrieve medication
/// plans and return the model for the medication plan view.
/// </summary>
namespace SteadyMedApiGateway.Controllers
{
    public class MedicationPlanController : Controller
    {
        //HTTP Client to make API calls to the microservices
        private readonly HttpClient _client;

        //URL for the medication plan microservice
        private const string MEDICATION_PLAN_SERVICE_URL = "http://localhost:50151/api/MedPlans/1";

        //Constructor
        public MedicationPlanController(HttpClient client)
        {
            _client = client;
        }

        //Index that retrieves the medication plan and then creates and returns the view model.
        public async Task<IActionResult> Index(int medicationPlanId)
        {
            HttpResponseMessage response = await _client.GetAsync(MEDICATION_PLAN_SERVICE_URL);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                MedicationPlan medicationPlan = JsonConvert.DeserializeObject<MedicationPlan>(responseBody);
                return View(medicationPlan);
            }
            return NotFound();
        }
    }
}
