using FinalNamespace;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StateNamespace;
using Newtonsoft.Json;
using parksNamespace;
using System.Net.Http;
using System.Globalization;
using WeatherSpace;
using WeatherSchemaData;

namespace IS7024_01_23.Pages
{
    public class ParkDetailModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        private readonly ILogger<IndexModel> _logger;

        //This will get the park name
        [BindProperty(SupportsGet = true)]
        public string ParkID { get; set; }
        public ParkDetailModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {
            string pID = Request.Query["parkName"].ToString();

            List<Datum> forecastDatas = new List<Datum>();
            
            Task<List<StateData>> ParkData = GetParkData(pID);
            List<StateData> parks = ParkData.Result;

            Task<List<ParkData>> parksdata = GetNewJson(parks);
            List<ParkData> modifiedparksdata = parksdata.Result;

            string cityState = modifiedparksdata[0].City + "," + modifiedparksdata[0].StateCode;

            Task<WeatherData> weatherData = GetWeatherData(cityState);
            WeatherData weathers = weatherData.Result;
            forecastDatas = weathers.Data;

            Task<List<WeatherInfo>> weatherdata = GetFinalWeather(forecastDatas);
            List<WeatherInfo> weatherForecast = weatherdata.Result;



            //Task<List<FinalData>> finalData = GetFinalJson(modifiedparksdata, forecastDatas) 

            ViewData["Parks"] = modifiedparksdata;
            ViewData["Weathers"] = weatherForecast;
        }
        private async Task<List<StateData>> GetParkData(string ParkID)
        {
            List<StateData> Parks = new List<StateData>();
            return await Task.Run(async () =>
            {
                var config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();
                string apikey = config["NPSkey"];

                var url = "https://developer.nps.gov/api/v1/parks?q=" + ParkID + "&limit=1&api_key=" + apikey;


                Task<HttpResponseMessage> parkTask = client.GetAsync(url);

                HttpResponseMessage parkResponse = await parkTask;
                Task<string> parkTaskString = parkResponse.Content.ReadAsStringAsync();
                string parkJson = parkTaskString.Result;
                StateJson nationalPark = StateJson.FromJson(parkJson);
                Parks = nationalPark.Data;
                return Parks;
            });
        }

        private async Task<WeatherData> GetWeatherData(string parkAddress)
        {
            var weather = new WeatherData();
            return await Task.Run(async () =>
            {
                Task<HttpResponseMessage> weatherTask = client.GetAsync("https://api.weatherbit.io/v2.0/forecast/daily?city="+ parkAddress + "&key=e1fc3e975b86438480ca1c4c8d3a41d4");
                HttpResponseMessage weatherResponse = await weatherTask;
                Task<string> weatherTaskString = weatherResponse.Content.ReadAsStringAsync();
                string weatherJson = weatherTaskString.Result;
                weather = WeatherData.FromJson(weatherJson);
                return weather;
            });
        }

        private async Task<List<WeatherInfo>> GetFinalWeather(List<Datum> data)
        { 
            List<WeatherInfo> weatherdata =  new List<WeatherInfo>();
            foreach (var dataItem in data)
            {
                var transformeddata = new WeatherInfo
                {
                    AppMaxTemp = dataItem.AppMaxTemp,
                    AppMinTemp = dataItem.AppMinTemp,
                    Clouds = dataItem.Clouds,
                    Datetime = dataItem.Datetime,
                    Precip = dataItem.Precip,
                    Description = dataItem.Weather.Description,
                    Code = dataItem.Weather.Code,
                    Icon = dataItem.Weather.Icon,
                    WindCdir = dataItem.WindCdir,
                    WindSpd = dataItem.WindSpd
                };
                weatherdata.Add(transformeddata);
            }
            return weatherdata;
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
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                LogException(ex);
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
