using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicationPlan_Service.Models;

namespace MedicationPlan_Service.Data
{
    /// <summary>
    /// Abstract Data Type to hold MedicationPlan objects in memory
    /// used for testing, actual implementation may just be direct reference
    /// to database.
    /// </summary>
    public class MedicationPlanCollection
    {
        //Stores all medication plans in memory, ensures that no duplicate medication plans exist
        private Dictionary<int, MedicationPlan> _plans;       

        /// <summary>
        /// Constructor
        /// </summary>
        public MedicationPlanCollection()
        {
            _plans = new Dictionary<int, MedicationPlan>();

            LoadPlans();  //Load plans into memory
        }

        /// <summary>
        /// Get A Medication Plan
        /// </summary>
        /// <param name="id">ID of Medication Plan to retrieve</param>
        /// <returns>Medication Plan</returns>
        public MedicationPlan GetPlan(int id)
        {
            return _plans.GetValueOrDefault(id);
        }

        /// <summary>
        /// Get a list of all MedicationPlans in the collection
        /// </summary>
        /// <returns>List of MedicationPlans</returns>
        public List<MedicationPlan> GetAllPlans()
        {
            return _plans.Values.ToList<MedicationPlan>();
        }

        /// <summary>
        /// Get all medication plans of a patient
        /// </summary>
        /// <param name="patientId">ID of patient</param>
        /// <returns>List of MedicationPlans of a patient</returns>
        public List<MedicationPlan> GetPatientPlans(int patientId)
        {
            var plans = (from p in _plans.Values
                         where p.PatientId == patientId
                         select p).ToList<MedicationPlan>();

            return plans;
        }

        /// <summary>
        /// Get most recent uncompleted medication plan of a SteadyMed device
        /// </summary>
        /// <param name="SteadyMedId">ID of SteadyMed device</param>
        /// <returns>The most recent uncompleted MedicationPlan or null</returns>
        public MedicationPlan GetSteadyMedPlan(int SteadyMedId)
        {
            var plan = from p in _plans.Values
                       where p.SteadyMedId == SteadyMedId && !p.Completed
                       select p;

            return plan.SingleOrDefault();
        }

        /// <summary>
        /// Add Medication Plan to connection
        /// </summary>
        /// <param name="plan">MedicationPlan to add</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool AddPlan(MedicationPlan plan)
        {
            bool result = _plans.TryAdd(_plans.Keys.Count + 1, plan);

            return result;
        }

        /// <summary>
        /// Remove Medication Plan from collection
        /// </summary>
        /// <param name="id">ID of Medicatoin Plan to remove</param>
        public void DeletePlan(int id)
        {
            _plans.Remove(id);
        }        

        /// <summary>
        /// Load mock MedicationPlans into the collection. (Used for testing)
        /// </summary>
        private void LoadPlans()
        {
            _plans.Add(1, new MedicationPlan
            {
                MedicationPlanId = 1,                
                PatientId = 2,
                PhysicianId = 1,
                Medication = "Tylenol",
                HourlyInterval = 4,
                PillsPerInterval = 2,
                SteadyMedId = 1,
                Completed = false
            });

            _plans.Add(2, new MedicationPlan
            {
                MedicationPlanId = 2,
                PatientId = 3,
                PhysicianId = 1,
                Medication = "Codeine",
                HourlyInterval = 8,
                PillsPerInterval = 1,
                SteadyMedId = 2,
                Completed = false
            });

            _plans.Add(3, new MedicationPlan
            {
                MedicationPlanId = 3,
                PatientId = 4,
                PhysicianId = 1,
                Medication = "Robitussin",
                HourlyInterval = 6,
                PillsPerInterval = 1,
                SteadyMedId = 3,
                Completed = true
            });

            _plans.Add(4, new MedicationPlan
            {
                MedicationPlanId = 4,
                PatientId = 4,
                PhysicianId = 1,
                Medication = "Aspirin",
                HourlyInterval = 6,
                PillsPerInterval = 10,
                SteadyMedId = 4,
                Completed = false
            });
        }

    }
}
