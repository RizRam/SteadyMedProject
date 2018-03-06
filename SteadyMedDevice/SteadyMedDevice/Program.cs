using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

/// <summary>
/// The simple console application defined in this class represents our end
/// user sensor/device. The final device would handle more operations such as
/// allowing the physician and other users to access the current state of the device.
/// It would also not have a console interface for our output but would be accessed
/// via the web interface.
/// </summary>
namespace SteadyMedDevice
{
    class Program
    {
        private static int STEADY_MED_ID = 2;
        private static string STEADYMED_SERVICE_BASEURL = "http://localhost:50151"; 
        static HttpClient client = new HttpClient();

        // The current state of the device which stipulates notifications to the user.
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

            //Display current plan for the purpose of this project.
            // the real device would only be access through an external interface.
            if (currentPlan != null)
            {
                Console.WriteLine($"{currentPlan.Medication}: {currentPlan.PillsPerInterval} pills every {currentPlan.HourlyInterval} hours.");
            }
            else
            {
                Console.WriteLine("No medication plan has been set");
            }

            // Check for Outside Requests
            // other operations such as retrieving the pill contents status
            // or usage history
        }

        /// <summary>
        /// Retrieve the device's medication from the medication service.
        /// This method connects to the medication service and is deserialized
        /// automaticcally with the help of the ReadAsAsync extension method.
        /// </summary>
        /// <param name="path">the service uri upon which to request data</param>
        /// <returns></returns>
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
