using FinalNamespace;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NationalPark;
using Newtonsoft.Json;
using parksNamespace;
using System.Globalization;
using WeatherSpace;

namespace IS7024_01_23.Pages
{
    public class IndexModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
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
            Task<List<Park>> ParkData = GetParkData();
            List<Park> parks = ParkData.Result;

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

            Task<List<ParkData>> parksdata = GetNewJson(parks);
            List<ParkData> modifiedparksdata = parksdata.Result;

            
            //This will work when we pass just one instance of the park data here.
            //Task<List<FinalData>> finaldata = GetFinalJson(oned, forecastDatas);
            //List<FinalData> finalJson = finaldata.Result;

            ViewData["Parks"] = modifiedparksdata;
            ViewData["Weathers"] = forecastDatas;
        }
        /// <summary>
        /// This function calls the National Parks API and gets information on all the parks.
        /// </summary>
        /// <returns>It returns an object of Park.</returns>
        private async Task<List<Park>> GetParkData()
        {
            List<Park> Parks = new List<Park>();
            return await Task.Run(async () =>
            {
                Task<HttpResponseMessage> parkTask = client.GetAsync("https://developer.nps.gov/api/v1/parks?limit=5&api_key=OYKRBWxnitTDzh8ovGqci8Ilgwr6l3gqIZ20QBHU");

                HttpResponseMessage parkResponse = await parkTask;
                Task<string> parkTaskString = parkResponse.Content.ReadAsStringAsync();
                string parkJson = parkTaskString.Result;
                NationalParkData nationalPark = NationalParkData.FromJson(parkJson);
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
            WeatherData weatherdata = new WeatherData();
            return await Task.Run(async () =>
            {
                Task<HttpResponseMessage> weatherTask = client.GetAsync("https://api.weatherbit.io/v2.0/forecast/daily?city=Cincinnati,OH&key=7cf5efad785c40b4b17b0d30370c265d");
                HttpResponseMessage weatherResponse = await weatherTask;
                Task<string> weatherTaskString = weatherResponse.Content.ReadAsStringAsync();
                string weatherJson = weatherTaskString.Result;
                weatherdata = WeatherData.FromJson(weatherJson);
                //weatherdata = weather.Data;
                return weatherdata;
            });
        }
        private async Task<List<ParkData>> GetNewJson(List<Park> parks)
        {
            List<ParkData> parkdata = new List<ParkData>();
            Address parkAddress = new Address();
            List<Address> parkAddress1 = new List<Address>();
            Image parkImages = new Image();
            List<Image> parkImages1 = new List<Image>();

            int count = 0;
            return await Task.Run(async () =>
            {
                foreach (Park park in parks)
                {
                    //Console.WriteLine(addresses.ToString());
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
                return parkdata;
            });
        }

        private static async Task<FinalData> GetFinalJson(ParkData parks, List<Datum> weather)
        {
            FinalData finaldata = new FinalData();
            List<WeatherDetails> weatherdatas = new List<WeatherDetails>();
            return await Task.Run(async () =>
            {
                for (int i = 0; i < weather.Count; i++)
                {
                    var weatherdata = new WeatherDetails
                    {
                        Date = weather[i].Datetime,
                        MaxTemp = weather[i].MaxTemp,
                        MinTemp = weather[i].MinTemp,
                        Description = weather[i].Weather.Description
                    };
                    weatherdatas.Add(weatherdata);
                }

                var data = new Parks
                {
                    ParkName = parks.ParkName,
                    Description = parks.Description,
                    Latitude = parks.Latitude,
                    Longitude = parks.Longitude,
                    Images = parks.Images,
                    City = parks.City,
                    StateCode = parks.StateCode,
                    Weather = weatherdatas
                };
                return finaldata;
            });

        }
    }
}