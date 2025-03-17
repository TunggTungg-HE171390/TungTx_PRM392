using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace eStoreClient.Pages.Product
{
    public class EditModel : PageModel
    {
        private readonly HttpClient client = null;
        private string ProductApiUrl = "";
        public BusinessObject.Product product = new BusinessObject.Product();
        public EditModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "http://localhost:5288/api/Products";
        }
        public async Task<IActionResult> OnGet(int? id = 1)
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl + "/" + id);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            product = JsonSerializer.Deserialize<BusinessObject.Product>(strData, options);

            return Page();
        }

        public async Task<IActionResult> OnPost(BusinessObject.Product product)
        {
            product.OrderDetails = null;
            var jsonContent = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");

            var response = await client.PutAsync(ProductApiUrl + "/" + product.ProductId, jsonContent);
            return Redirect("/Product/Edit?id=" + product.ProductId);
        }
    }
}
