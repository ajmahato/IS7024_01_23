using FinalNamespace;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StateNamespace;
using Newtonsoft.Json;
using parksNamespace;
using System.Globalization;
using WeatherSpace;

namespace IS7024_01_23.Pages
{
    public class ViewParksModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        private readonly ILogger<IndexModel> _logger;

        public ViewParksModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string statecode = Request.Query["stateCode"].ToString();

            Task<List<StateData>> ParkData = GetParkData(statecode);
            List<StateData> parks = ParkData.Result;

            Task<List<ParkData>> parksdata = GetNewJson(parks);
            List<ParkData> modifiedparksdata = parksdata.Result;

            ViewData["Parks"] = modifiedparksdata;
        }

        private async Task<List<StateData>> GetParkData(string statecode)
        {
            List<StateData> Parks = new List<StateData>();
            try
            {

                var config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

                string apikey = config["NPSkey"];
                string url = $"https://developer.nps.gov/api/v1/parks?stateCode={statecode}&limit=5&api_key=OYKRBWxnitTDzh8ovGqci8Ilgwr6l3gqIZ20QBHU";

                HttpResponseMessage parkResponse = await client.GetAsync(url);
                parkResponse.EnsureSuccessStatusCode();  // Ensure a successful response

                string parkJson = await parkResponse.Content.ReadAsStringAsync();
                StateJson nationalPark = StateJson.FromJson(parkJson);
                Parks = nationalPark.Data;
            }
            catch  (Exception ex)
            {
                LogException(ex);
            }
            return Parks;
        }


        private async Task<List<ParkData>> GetNewJson(List<StateData> parks)
        {
            List<ParkData> parkdata = new List<ParkData>();
            Address parkAddress = new Address();
            List<Address> parkAddress1 = new List<Address>();
            Image parkImages = new Image();
            List<Image> parkImages1 = new List<Image>();

            try
            {
                foreach (StateData park in parks)
                {
                    parkAddress = park.Addresses[0];
                    parkImages = park.Images[0];
                    parkAddress1.Add(parkAddress);
                    parkImages1.Add(parkImages);
                }

                for (int i = 0; i < parkImages1.Count; i++)
                {

                    var data = new ParkData
                    {
                        ParkName = parks[i].FullName,
                        ParkID = parks[i].ParkCode,
                        Description = parks[i].Description,
                        Latitude = parks[i].Latitude,
                        Longitude = parks[i].Longitude,
                        Images = parkImages1[i].Url.ToString(),
                        City = parkAddress1[i].City,
                        StateCode = parkAddress1[i].StateCode
                    };
                    parkdata.Add(data);


                }
                ViewData["Address"] = parkAddress1;
                ViewData["Images"] = parkImages1;
                ViewData["ErrorMessage"] = "Noerror";
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                LogException(ex);
                ViewData["ErrorMessage"] = "Error";
            }
            return parkdata;
        }


      

        /// <summary>
        /// This function is used to log any error into a text file for future reference.
        /// </summary>
        /// <param name="ex"></param>
        private void LogException(Exception ex)
        {
            try
            {
                // Log the exception to a text file
                using (StreamWriter writer = new StreamWriter("error_log.txt", true))
                {
                    writer.WriteLine($"[{DateTime.Now}] {ex.GetType().Name}: {ex.Message}");
                    writer.WriteLine($"StackTrace: {ex.StackTrace}");
                    writer.WriteLine(new string('-', 50));
                }
            }
            catch
            {
                // If logging fails, just ignore it to avoid infinite loop of exceptions
            }
        }

    }
}