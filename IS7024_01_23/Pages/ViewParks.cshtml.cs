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
        public static string ConvertState(string state)
        {
            switch (state)
            {
                case "AL":
                    return "Alabama";
                case "AK":
                    return "Alaska";
                case "AR":
                    return "Arkansas";
                case "AZ":
                    return "Arizona";
                case "CA":
                    return "California";
                case "CO":
                    return "Colorado";
                case "CT":
                    return "Connecticut";
                case "DE":
                    return "Delaware";
                case "FL":
                    return "Florida";
                case "GA":
                    return "Georgia";
                case "HI":
                    return "Hawaii";
                case "ID":
                    return "Idaho";
                case "IL":
                    return "Illinois";
                case "IN":
                    return "Indiana";
                case "IA":
                    return "Iowa";
                case "KS":
                    return "Kansas";
                case "KY":
                    return "Kentucky";
                case "LA":
                    return "Louisiana";
                case "ME":
                    return "Maine";
                case "MD":
                    return "Maryland";
                case "MA":
                    return "Massachusetts";
                case "MI":
                    return "Michigan";
                case "MN":
                    return "Minnesota";
                case "MS":
                    return "Mississippi";
                case "MO":
                    return "Missouri";
                case "MT":
                    return "Montana";
                case "NE":
                    return "Nebraska";
                case "NV":
                    return "Nevada";
                case "NH":
                    return "New Hampshire";
                case "NJ":
                    return "New Jersey";
                case "NM":
                    return "New Mexico";
                case "NY":
                    return "New York";
                case "NC":
                    return "North Carolina";
                case "ND":
                    return "North Dakota";
                case "OH":
                    return "Ohio";
                case "OK":
                    return "Oklahoma";
                case "OR":
                    return "Oregon";
                case "PA":
                    return "Pennsylvania";
                case "RI":
                    return "Rhode Island";
                case "SC":
                    return "South Carolina";
                case "SD":
                    return "South Dakota";
                case "TN":
                    return "Tennessee";
                case "TX":
                    return "Texas";
                case "UT":
                    return "Utah";
                case "VT":
                    return "Vermont";
                case "VA":
                    return "Virginia";
                case "WA":
                    return "Washington";
                case "WV":
                    return "West Virginia";
                case "WI":
                    return "Wisconsin";
                case "WY":
                    return "Wyoming";
                default:
                    return state;
            }
        }


        static readonly HttpClient client = new HttpClient();
        private readonly ILogger<IndexModel> _logger;

        public ViewParksModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //var task = client.GetAsync("https://developer.nps.gov/api/v1/parks?limit=5&api_key=OYKRBWxnitTDzh8ovGqci8Ilgwr6l3gqIZ20QBHU");
            //var WeatherTask = client.GetAsync("https://api.weatherbit.io/v2.0/forecast/daily?city=Cincinnati,OH&key=7cf5efad785c40b4b17b0d30370c265d");
            //HttpResponseMessage result = task.Result;
            //HttpResponseMessage WeatherResult = WeatherTask.Result;
            //List<Park> ParkData = new List<Park>();
            List<Datum> forecastDatas = new List<Datum>();
            //List<Address> Addresses = new List<Address>();
            //List<Contacts> Contact = new List<Contacts>();
            //List<Image> Images = new List<Image>();
            //List<OperatingHour> OperatingHours = new List<OperatingHour>();


            ////This is useful
            //var NationalParks = new NationalParkData();
            //if (result.IsSuccessStatusCode)
            //{
            //    Task<string> readString=  result.Content.ReadAsStringAsync();
            //    string jsonString = readString.Result;
            //    NationalParks = NationalParkData.FromJson(jsonString);
            //    Parks = NationalParks.Data;
            //    //Parks = 
            //}

            string statecode = Request.Query["stateCode"].ToString();

            Task<List<StateData>> ParkData = GetParkData(statecode);
            List<StateData> parks = ParkData.Result;

            Task<WeatherData> weatherData = GetWeatherData();
            WeatherData weathers = weatherData.Result;
            forecastDatas = weathers.Data;

            //This is useful
            //var Weathers = new WeatherData();
            //if(WeatherResult.IsSuccessStatusCode)
            //{
            //    Task<string> readStrng = WeatherResult.Content.ReadAsStringAsync();
            //    string jsonString = readStrng.Result;
            //    Weathers = WeatherData.FromJson(jsonString);
            //    forecastDatas = Weathers.Data;
            //}

            // attempted try catch, clicking Arkansas from index page breaks application
            try
            {
                Task<List<ParkData>> parksdata = GetNewJson(parks);
                List<ParkData> modifiedparksdata = parksdata.Result;
                ViewData["Parks"] = modifiedparksdata;
                ViewData["Weathers"] = forecastDatas;
            }
            catch (Exception e)
            {
                LogError(e, "Shape processing failed.");
                throw;
            }
      

           
        }

        private void LogError(Exception e, string v)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This function calls the National Parks API and gets information on all the parks.
        /// </summary>
        /// <returns>It returns an object of Park.</returns>
        private async Task<List<StateData>> GetParkData(string statecode)
        {
            List<StateData> Parks = new List<StateData>();
            return await Task.Run(async () =>
            {
                var config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();
                string apikey = config["NPSkey"];

                var url = "https://developer.nps.gov/api/v1/parks?stateCode=" + statecode + "&limit=5&api_key="+ "OYKRBWxnitTDzh8ovGqci8Ilgwr6l3gqIZ20QBHU";
                
                
                Task<HttpResponseMessage> parkTask = client.GetAsync(url);

                HttpResponseMessage parkResponse = await parkTask;
                Task<string> parkTaskString = parkResponse.Content.ReadAsStringAsync();
                string parkJson = parkTaskString.Result;
                StateJson nationalPark = StateJson.FromJson(parkJson);
                Parks = nationalPark.Data;
                return Parks;
            });
        }
        /// <summary>
        /// This function calls the weatherbit API and gets the weather forecast for the next seven days.
        /// </summary>
        /// <returns>It returns an object of WeatherData.</returns>
        private async Task<WeatherData> GetWeatherData()
        {
            var weather = new WeatherData();
            return await Task.Run(async () =>
            {
                Task<HttpResponseMessage> weatherTask = client.GetAsync("https://api.weatherbit.io/v2.0/forecast/daily?city=Cincinnati,OH&key=e1fc3e975b86438480ca1c4c8d3a41d4");
                HttpResponseMessage weatherResponse = await weatherTask;
                Task<string> weatherTaskString = weatherResponse.Content.ReadAsStringAsync();
                string weatherJson = weatherTaskString.Result;
                weather = WeatherData.FromJson(weatherJson);
                return weather;
            });
        }

        private async Task<List<ParkData>> GetNewJson(List<StateData> parks)
        {
            List<ParkData> parkdata = new List<ParkData>();
            Address parkAddress = new Address();
            List<Address> parkAddress1 = new List<Address>();
            Image parkImages = new Image();
            List<Image> parkImages1 = new List<Image>();

            int count = 0;
            return await Task.Run(async () =>
            {
                foreach (StateData park in parks)
                {
                    //Console.WriteLine(addresses.ToString());
                    parkAddress = park.Addresses[0];
                    parkImages = park.Images[0];
                    parkAddress1.Add(parkAddress);
                    parkImages1.Add(parkImages);
                }
                //foreach (Park image in parks)
                //{
                //    //Console.WriteLine(image.ToString());
                //    parkImages.Add(image);
                //}
                for (int i = 0; i < parkImages1.Count; i++)
                {

                    var data = new ParkData
                    {
                        ParkName = parks[i].FullName,
                        Description = parks[i].Description,
                        Latitude = parks[i].Latitude,
                        Longitude = parks[i].Longitude,
                        Images = parkImages1[i].Url.ToString(),
                        City = parkAddress1[i].City,
                        StateCode = ConvertState(parkAddress1[i].StateCode)
                    };
                    parkdata.Add(data);


                }
                ViewData["Address"] = parkAddress1;
                ViewData["Images"] = parkImages1;
                return parkdata;
            });
        }
    }
}