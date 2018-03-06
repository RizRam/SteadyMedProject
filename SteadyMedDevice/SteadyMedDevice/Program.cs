using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SteadyMedDevice
{
    /// <summary>
    /// Point of entry for SteadyMedDevice interaction program
    /// </summary>
    class Program
    {
        //ID of this SteadyMed device
        private static int STEADY_MED_ID = 2;
        //URL of SteadyMed Service for REST requests
        private static string STEADYMED_SERVICE_BASEURL = "http://localhost:50151"; 
        //Handles HTTP requests
        static HttpClient client = new HttpClient();
        //Current active Medication Plan
        static MedicationPlan currentPlan;

        static void Main(string[] args)
        {
            currentPlan = null;

            //Execution loop
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

                //Updates every 10 seconds.  Could be longer for actual
                //implementation
                System.Threading.Thread.Sleep(10000);
                
                
            }
        }

        /// <summary>
        /// Performs asynchronous requests to REST service
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Performs aynchronous request to get latest MedicationPlan from the MedicationPlan service.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static async Task<MedicationPlan> GetMedicationPlan(string path)
        { 
            var request = new HttpRequestMessage(HttpMethod.Get, path);

            MedicationPlan plan = null;
            HttpResponseMessage response = await client.GetAsync(request.RequestUri);
            if (response.IsSuccessStatusCode)
            {
                plan = await response.Content.ReadAsAsync<MedicationPlan>();
            }

            return plan;
        }


    }
}
