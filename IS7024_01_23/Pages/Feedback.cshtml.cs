using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.IO;

namespace IS7024_01_23.Pages
{
    public class FeedbackModel : PageModel
    {
        private readonly ILogger<FeedbackModel> _logger;

        public FeedbackModel(ILogger<FeedbackModel> logger)
        {
            _logger = logger;
        }

        public List<FormData> FeedbackData { get; set; }
        public void OnGet()
        {
            FeedbackData = GetFormData();
        }

        private List<FormData> GetFormData()
        {
            // Specify the path to your JSON file
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "form_data.json");

            // Read JSON data from the file
            return System.IO.File.Exists(jsonFilePath)
                ? JsonConvert.DeserializeObject<List<FormData>>(System.IO.File.ReadAllText(jsonFilePath))
                : new List<FormData>();
        }



        public IActionResult OnPost()
        {
            // Retrieve form data from the request
            var formData = new FormData
            {
                Name = Request.Form["Name"],
                Email = Request.Form["Email"],
                DateOfVisit = Request.Form["DateOfVisit"],
                ParkName = Request.Form["ParkName"],
                Comments = Request.Form["comments"]
            };

            // Save form data to a JSON file
            SaveToJsonFile(formData);

            // You can perform additional processing or redirect the user after saving the data
            return RedirectToPage("/Feedback"); // Redirect to the home page for example
        }

        [HttpPost]
        private void SaveToJsonFile(FormData formData)
        {
            // Specify the path to your JSON file
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "form_data.json");

            // Read existing JSON data, or create an empty list if the file doesn't exist
            List<FormData> existingData = System.IO.File.Exists(jsonFilePath)
             ? JsonConvert.DeserializeObject<List<FormData>>(System.IO.File.ReadAllText(jsonFilePath))
             : new List<FormData>();


            // Add the new form data to the list
            existingData.Add(formData);

            // Write the updated list back to the JSON file
            System.IO.File.WriteAllText(jsonFilePath, JsonConvert.SerializeObject(existingData, Formatting.Indented));
        }
    }
}