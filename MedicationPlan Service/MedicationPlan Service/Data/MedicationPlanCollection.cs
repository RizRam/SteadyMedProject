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

        public List<MedicationPlan> GetAllPlans()
        {
            return _plans.Values.ToList<MedicationPlan>();
        }

        //Add Medication Plan to connection
        public bool AddPlan(MedicationPlan plan)
        {
            return _plans.TryAdd(plan.MedicationPlanId, plan);      
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
            _plans.Add(1, new MedicationPlan { MedicationPlanId = 1, PatientId = 1, PhysicianId = 1, HourlyInterval = 4, PillsPerInterval = 2, SteadyMedId = 1 });
            _plans.Add(2, new MedicationPlan { MedicationPlanId = 2, PatientId = 2, PhysicianId = 1, HourlyInterval = 8, PillsPerInterval = 1, SteadyMedId = 2 });
            _plans.Add(3, new MedicationPlan { MedicationPlanId = 3, PatientId = 3, PhysicianId = 2, HourlyInterval = 6, PillsPerInterval = 1, SteadyMedId = 3 });
        }

    }
}
