using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicationPlan_Service.Models;

namespace MedicationPlan_Service.Data
{
    public class MedicationPlanCollection
    {
        //Stores all medication plans in memory, ensures that no duplicate medication plans exist
        private Dictionary<int, MedicationPlan> _plans;
       

        //Constructor
        public MedicationPlanCollection()
        {
            _plans = new Dictionary<int, MedicationPlan>();

            LoadPlans();  //Load plans into memory
        }

        //Get A Medication Plan using Id
        public MedicationPlan GetPlan(int id)
        {
            return _plans.GetValueOrDefault(id);
        }

        //Get all plans
        public List<MedicationPlan> GetAllPlans()
        {
            return _plans.Values.ToList<MedicationPlan>();
        }

        //Get all medication plans of a patient
        public List<MedicationPlan> GetPatientPlans(int patientId)
        {
            var plans = (from p in _plans.Values
                         where p.PatientId == patientId
                         select p).ToList<MedicationPlan>();

            return plans;
        }

        //Get most recent uncompleted medication plan of a SteadyMed device
        public MedicationPlan GetSteadyMedPlan(int SteadyMedId)
        {
            var plan = from p in _plans.Values
                       where p.SteadyMedId == SteadyMedId && !p.Completed
                       select p;

            return plan.SingleOrDefault();
        }

        //Add Medication Plan to connection
        public bool AddPlan(MedicationPlan plan)
        {
            bool result = _plans.TryAdd(plan.MedicationPlanId, plan);

            return result;
        }

        //Remove Medication Plan using Id
        public void DeletePlan(int id)
        {
            _plans.Remove(id);
        }        

        //Load medication plans into private 
        //Future implementation will load from data from 
        private void LoadPlans()
        {
            _plans.Add(1, new MedicationPlan
            {
                MedicationPlanId = 1,                
                PatientId = 1,
                PhysicianId = 2,
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
                PhysicianId = 4,
                Medication = "Codeine",
                HourlyInterval = 8,
                PillsPerInterval = 1,
                SteadyMedId = 2,
                Completed = false
            });

            _plans.Add(3, new MedicationPlan
            {
                MedicationPlanId = 3,
                PatientId = 5,
                PhysicianId = 6,
                Medication = "Robitussin",
                HourlyInterval = 6,
                PillsPerInterval = 1,
                SteadyMedId = 3,
                Completed = true
            });

            _plans.Add(4, new MedicationPlan
            {
                MedicationPlanId = 4,
                PatientId = 7,
                PhysicianId = 6,
                Medication = "Aspirin",
                HourlyInterval = 6,
                PillsPerInterval = 10,
                SteadyMedId = 3,
                Completed = false
            });
        }

    }
}
