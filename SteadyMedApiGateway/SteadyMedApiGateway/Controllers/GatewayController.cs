using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SteadyMedApiGateway.Models.PatientMedicationPlan;
using SteadyMedApiGateway.Models.PatientModel;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

namespace SteadyMedApiGateway.Controllers
{
    [Route("api/[controller]")]
    public class GatewayController : Controller
    {
        //HTTP Client
        private static HttpClient _client = new HttpClient();

        //HTTP Response Message
        private static HttpResponseMessage response;

        //Medication Plan microsevice URL
        private const string MEDICATION_PLAN_URL = "http://localhost:50151/api/MedPlans";

        //Patient Medication Plan microservice URL
        private const string PATIENT_PLANS_URL = "http://localhost:50151/api/PatientMedPlans";

        //Patient Profile microservice URL
        private const string PATIENT_PROFILE_URL = "http://localhost:56693/api/physicianprofile";

        [HttpGet]
        public static async Task<List<MedicationPlan>> GetPatientMedicationPlans(int id)
        {
            List<MedicationPlan> medicationPlans = new List<MedicationPlan>();
            response = await _client.GetAsync(String.Format("{0}/{1}", PATIENT_PLANS_URL, id));
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                medicationPlans = JsonConvert.DeserializeObject<List<MedicationPlan>>(responseBody);
            }
            return medicationPlans;
        }

        /// <summary>
        /// Creates a medication plan and returns true if the operation was successful or else false. 
        /// </summary>
        [HttpPost]
        public static Boolean CreateMedicationPlan(MedicationPlan createPlan)
        {
            var jsonRequest = JsonConvert.SerializeObject(createPlan);
            var buffer = System.Text.Encoding.UTF8.GetBytes(jsonRequest);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var result = _client.PostAsync(MEDICATION_PLAN_URL, byteContent);

            return result.IsCompletedSuccessfully ? true : false;
        }

        [HttpGet]
        public IActionResult Help()
        {
            return Ok();
        }

        /// <summary>
        /// Returns a list of patients associated with the Physician
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("api/[controller]")]
        public static async Task<IEnumerable<Patient>> GetPhysicianPatients(int id)
        {
            IEnumerable<Patient> patients = new List<Patient>();
            HttpResponseMessage response = await _client.GetAsync(String.Format("{0}/{1}", PATIENT_PROFILE_URL, 1));
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                patients = JsonConvert.DeserializeObject<List<Patient>>(responseBody);
            }
            return patients;
        }
    }
}