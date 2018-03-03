using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SteadyMedClient.Models;

namespace SteadyMedClient.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            PatientViewModel model = new PatientViewModel();

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

            model.Patient = temp;
            model.NewMedPlan = new MedicationPlan();

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateMedicationPlan(Patient patient)
        {
            return NotFound();
        }

    }
}