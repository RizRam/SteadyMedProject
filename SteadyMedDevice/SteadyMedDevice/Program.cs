using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SteadyMedDevice
{
    class Program
    {
        private static int STEADY_MED_ID = 2;
        private static string STEADYMED_SERVICE_BASEURL = "http://localhost:50151"; 
        static HttpClient client = new HttpClient();


        static MedicationPlan currentPlan;

        static void Main(string[] args)
        {
            currentPlan = null;

            while(true)
            {
                try
                {
                    RunAsync().GetAwaiter().GetResult();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                System.Threading.Thread.Sleep(10000);
                
                
            }
        }

        static async Task RunAsync()
        {
            //Get current Plan
            currentPlan = await GetMedicationPlan(STEADYMED_SERVICE_BASEURL + $"/api/SteadyMedPlans/{STEADY_MED_ID}");   

            //Display current plan
            if (currentPlan != null)
            {
                Console.WriteLine($"{currentPlan.Medication}: {currentPlan.PillsPerInterval} pills every {currentPlan.HourlyInterval} hours.");
            }
            else
            {
                Console.WriteLine("No medication plan has been set");
            }

            //Check for Outside Requests

        }

        static async Task<MedicationPlan> GetMedicationPlan(string path)
        { 
            var request = new HttpRequestMessage(HttpMethod.Get, STEADYMED_SERVICE_BASEURL + $"/api/SteadyMedPlans/{STEADY_MED_ID}");

            MedicationPlan plan = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                plan = await response.Content.ReadAsAsync<MedicationPlan>();
            }

            return plan;
        }


    }
}
