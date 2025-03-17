using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eStoreClient.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = null;
        private string MemberApiUrl = "";
        public List<BusinessObject.Product> listProduct = new List<BusinessObject.Product>();
        public IndexModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MemberApiUrl = "http://localhost:5288/api/Products";
        }
        public async Task<IActionResult> OnGet()
        {
            HttpResponseMessage response = await client.GetAsync(MemberApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            listProduct = JsonSerializer.Deserialize<List<BusinessObject.Product>>(strData, options);

            return Page();
        }
    }
}
