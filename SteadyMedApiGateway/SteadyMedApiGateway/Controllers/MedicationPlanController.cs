using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using SteadyMedApiGateway.Models.PatientMedicationPlan;
using System.Diagnostics;

namespace SteadyMedApiGateway.Controllers
{
    public class MedicationPlanController : Controller
    {
        //HTTP Client to make API calls to the microservices
        private readonly HttpClient _client;

        private const string MEDICATION_PLAN_SERVICE_URL = "http://localhost:50151/api/MedPlans/1";

        public MedicationPlanController(HttpClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index(int medicationPlanId)
        {
            HttpResponseMessage response = await _client.GetAsync(MEDICATION_PLAN_SERVICE_URL);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                MedicationPlan medicationPlan = JsonConvert.DeserializeObject<MedicationPlan>(responseBody);
                return View(medicationPlan);
            }
            return View();
        }
    }
}
