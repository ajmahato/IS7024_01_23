using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;

namespace IS7024_01_23.Pages
{
    public class StateListModel : PageModel
    {

        public void OnGet()
        {
            Task<List<StateDataModel>> stateName = GetData();
            List<StateDataModel> stateDataModels = stateName.Result;
            ViewData["StateList"]= stateDataModels;
        }

        private async Task<List<StateDataModel>> GetData()
        {
            List<StateDataModel> StateName = null;
            try
            {
                string url = "https://neighborhoodwatch.azurewebsites.net/api/values";
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage apiResponse = await client.GetAsync(url);
                    apiResponse.EnsureSuccessStatusCode();
                    var list = await apiResponse.Content.ReadAsStringAsync();
                    StateName = StateDataModel.FromJson(list);
                }
            }
            catch(Exception ex)
            {
                ViewData["error"] = "The other team's API is not working. Please try visiting \n https://neighborhoodwatch.azurewebsites.net/api/values";
                LogException(ex);
            }
            return StateName;
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
