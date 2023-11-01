using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NationalPark;
using Newtonsoft.Json;

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
            HttpResponseMessage result = task.Result;
            List<Park> Parks = new List<Park>();
            //List<Address> Addresses = new List<Address>();
            //List<Contacts> Contact = new List<Contacts>();
            //List<Image> Images = new List<Image>();
            //List<OperatingHour> OperatingHours = new List<OperatingHour>();

            var Welcomes = new Welcome();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString=  result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                Welcomes = Welcome.FromJson(jsonString);
                Parks = Welcomes.Data;
                //Parks = 
            }
            ViewData["Parks"] = Parks;
        }
    }
}