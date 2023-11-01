using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NationalPark;
using Newtonsoft.Json;
using Weather;

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
            var task = client.GetAsync("https://developer.nps.gov/api/v1/parks?limit=5&api_key=OYKRBWxnitTDzh8ovGqci8Ilgwr6l3gqIZ20QBHU");
            var WeatherTask = client.GetAsync("https://api.weatherbit.io/v2.0/forecast/daily?city=Cincinnati,OH&key=7cf5efad785c40b4b17b0d30370c265d");
            HttpResponseMessage result = task.Result;
            HttpResponseMessage WeatherResult = WeatherTask.Result;
            List<Park> Parks = new List<Park>();
            List<Datum> forecastDatas = new List<Datum>();
            //List<Address> Addresses = new List<Address>();
            //List<Contacts> Contact = new List<Contacts>();
            //List<Image> Images = new List<Image>();
            //List<OperatingHour> OperatingHours = new List<OperatingHour>();

            var NationalParks = new NationalParkData();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString=  result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                NationalParks = NationalParkData.FromJson(jsonString);
                Parks = NationalParks.Data;
                //Parks = 
            }
            var Weathers = new WeatherData();
            if(WeatherResult.IsSuccessStatusCode)
            {
                Task<string> readStrng = WeatherResult.Content.ReadAsStringAsync();
                string jsonString = readStrng.Result;
                Weathers = WeatherData.FromJson(jsonString);
                forecastDatas = Weathers.Data;
            }
            ViewData["Parks"] = Parks;
            ViewData["Weathers"] = Weathers;
        }
    }
}