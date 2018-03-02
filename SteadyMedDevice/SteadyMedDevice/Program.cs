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
                Console.WriteLine("Loop");
                
            }
        }

        static async Task RunAsync()
        {
            //Set up Http Client
            Uri steadyMedServiceUri = new Uri(STEADYMED_SERVICE_BASEURL);
            client.BaseAddress = steadyMedServiceUri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            //Get current Plan
            currentPlan = await GetMedicationPlan(steadyMedServiceUri.OriginalString + $"/api/SteadyMedPlans/{STEADY_MED_ID}");   

            //Display current plan
            if (currentPlan != null)
            {
                Console.WriteLine($"{currentPlan.Medication}: {currentPlan.PillsPerInterval} pills every {currentPlan.HourlyInterval} hours.");
            }

        }

        static async Task<MedicationPlan> GetMedicationPlan(string path)
        {
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
