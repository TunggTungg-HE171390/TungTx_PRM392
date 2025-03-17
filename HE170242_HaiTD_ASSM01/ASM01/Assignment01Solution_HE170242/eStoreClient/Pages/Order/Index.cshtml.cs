using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eStoreClient.Pages.Order
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = null;
        private string OrderApiUrl = "";
        public List<BusinessObject.Order> listOrder = new List<BusinessObject.Order>();
        public IndexModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            OrderApiUrl = "http://localhost:5288/api/Orders";
        }
        public async Task<IActionResult> OnGet()
        {
            HttpResponseMessage response = await client.GetAsync(OrderApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            listOrder = JsonSerializer.Deserialize<List<BusinessObject.Order>>(strData, options);

            return Page();
        }
    }
}
