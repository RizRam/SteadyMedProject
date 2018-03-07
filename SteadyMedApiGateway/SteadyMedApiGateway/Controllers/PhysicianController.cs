using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using SteadyMedApiGateway.Models.PatientModel;
using SteadyMedApiGateway.Models.PhysicianViewModels;
using Newtonsoft.Json;

/// <summary>
/// Author: Craig Rainey
/// Controller to link the front-end with the service to retrieve patients associated with a physician.
/// </summary>
namespace SteadyMedApiGateway.Controllers
{
    public class PhysicianController : Controller
    {
        //HTTP Client used for REST calls
        private HttpClient httpClient;

        //URL of the service
        private const string PATIENT_PROFILE_URL = "http://localhost:56693/api/physicianprofile";

        //Constructor
        public PhysicianController(HttpClient client)
        {
            httpClient = client;
        }

        //Returns the controller for the index view. This will get all of the patients associated with the physician.
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(new PhysicianViewModel(){ Patients = GatewayController.GetPhysicianPatients(1).Result });
        }
    }
}