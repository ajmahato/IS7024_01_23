using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;

namespace IS7024_01_23.Pages
{
    public class StateListModel : PageModel
    {
        private IList<StateDataModel> stateName = new List<StateDataModel>();

        public void OnGet()
        {
            string url = $"https://neighborhoodwatch.azurewebsites.net/api/values";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send GET request to the API
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the content as a string
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        stateName = System.Text.Json.JsonSerializer.Deserialize<List<StateDataModel>>(apiResponse);

                        // Split the response into a list based on a delimiter (if applicable)
                        //stateName = apiResponse.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                        ViewData["StateList"] = stateName;

                    }
                    else
                    {
                        throw new Exception($"API request failed with status code: {response.StatusCode}");
                        // Handle non-success status codes
                        // You can throw an exception, log an error, or handle it as needed
                    }
                }
                catch (Exception ex)
                {
                    LogException(ex);
                }
            }
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
