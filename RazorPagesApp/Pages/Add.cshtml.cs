using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace RazorPagesApp.Pages
{
    public class AddModel : PageModel
    {
        // IHttpClientFactory set using dependency injection 
        private readonly IHttpClientFactory _httpClientFactory;

        public AddModel(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        // Add the data model and bind the form data to the page model properties
        [BindProperty]
        public FruitModel FruitModels { get; set; }

        // OnPost() is async since HTTP operations should be performed async
        public async Task<IActionResult> OnPost()
        {
            // Serialize the information to be added to the database
            var jsonContent = new StringContent(JsonSerializer.Serialize(FruitModels),
                Encoding.UTF8,
                "application/json");

            // Create the HTTP client using the FruitAPI named factory
            var httpClient = _httpClientFactory.CreateClient("FruitAPI");

            // Execute the POST operation and store the response. The parameters in 
            // PostAsync direct the POST to use the base address and passes the 
            // serialized data to the API
            using HttpResponseMessage response = await httpClient.PostAsync("/fruitlist", jsonContent);

            // If the POST was successful return to the home (Index) page 
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Index");
            }
            return Page();

        }

    }
}
