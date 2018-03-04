using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using SteadyMedApiGateway.Models.MedicationPlan;
using System.Diagnostics;

namespace SteadyMedApiGateway.Controllers
{
    public class MedicationPlanController : Controller
    {
        private HttpClient client = new HttpClient();

        private const string MEDICATION_PLAN_SERVICE_URL = "http://localhost:50151/api/MedPlans/1";

        public async Task<IActionResult> Index(int medicationPlanId)
        {
            HttpResponseMessage response = await client.GetAsync(MEDICATION_PLAN_SERVICE_URL);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                MedicationPlan medicationPlan = JsonConvert.DeserializeObject<MedicationPlan>(responseBody);
                Debug.WriteLine("Medication Patient ID: " + medicationPlan.PatientId);
                return View(medicationPlan);
            }
            return View();
        }
    }
}
