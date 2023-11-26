using FinalNamespace;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StateNamespace;

namespace IS7024_01_23.Pages
{
    public class AutoCompleteStateNameModel : PageModel
    {
        private IList<string> stateName = new List<string>();
        public JsonResult OnGet(string searchTerm)
        {
            //string url = $"https://neighborhoodwatch.azurewebsites.net/api/values";
            //using (HttpClient client = new HttpClient())
            //{
            //    try
            //    {
            //        // Send GET request to the API
            //        HttpResponseMessage response = client.GetAsync(url).Result;
            //        if (response.IsSuccessStatusCode)
            //        {
            //            // Read the content as a string
            //            string apiResponse = response.Content.ReadAsStringAsync().Result;

            //            // Split the response into a list based on a delimiter (if applicable)
            //            stateName = apiResponse.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            //        }
            //        else
            //        {
            //            throw new Exception($"API request failed with status code: {response.StatusCode}");
            //            // Handle non-success status codes
            //            // You can throw an exception, log an error, or handle it as needed
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        LogException(ex);
            //    }
            //}

            stateName.Add("Alabama");
            stateName.Add("Alaska");
            stateName.Add("American Samoa");
            stateName.Add("Arizona");
            stateName.Add("Arkansas");
            stateName.Add("California");
            stateName.Add("Colorado");
            stateName.Add("Connecticut");
            stateName.Add("Delaware");
            stateName.Add("District of Columbia");
            stateName.Add("Florida");
            stateName.Add("Georgia");
            stateName.Add("Guam");
            stateName.Add("Hawaii");
            stateName.Add("Idaho");
            stateName.Add("Illinois");
            stateName.Add("Indiana");
            stateName.Add("Iowa");
            stateName.Add("Kansas");
            stateName.Add("Kentucky");
            stateName.Add("Louisiana");
            stateName.Add("Maine");
            stateName.Add("Maryland");
            stateName.Add("Massachusetts");
            stateName.Add("Michigan");
            stateName.Add("Minnesota");
            stateName.Add("Mississippi");
            stateName.Add("Missouri");
            stateName.Add("Montana");
            stateName.Add("Nebraska");
            stateName.Add("Nevada");
            stateName.Add("New Hampshire");
            stateName.Add("New Jersey");
            stateName.Add("New Mexico");
            stateName.Add("New York");
            stateName.Add("North Carolina");
            stateName.Add("North Dakota");
            stateName.Add("Northern Mariana Islands");
            stateName.Add("Ohio");
            stateName.Add("Oklahoma");
            stateName.Add("Oregon");
            stateName.Add("Pennsylvania");
            stateName.Add("Puerto Rico");
            stateName.Add("Rhode Island");
            stateName.Add("South Carolina");
            stateName.Add("South Dakota");
            stateName.Add("Tennessee");
            stateName.Add("Texas");
            stateName.Add("U.S. Virgin Islands");
            stateName.Add("Utah");
            stateName.Add("Vermont");
            stateName.Add("Virginia");
            stateName.Add("Washington");
            stateName.Add("West Virginia");
            stateName.Add("Wisconsin");
            stateName.Add("Wyoming");


            IList<string> matchingStateName = new List<string>();
            foreach (string stateName in stateName)
            {
                if (stateName == searchTerm)
                {
                    matchingStateName.Add(stateName);
                }
            }
            return new JsonResult(matchingStateName);
        }

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
