using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace eStoreClient.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient client = null;
        private string ProductApiUrl = "";
        public BusinessObject.Product product = new BusinessObject.Product();
        public List<Category> categories = new List<Category>();
        public CreateModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "http://localhost:5288/api/Products";
        }
        public async Task<IActionResult> OnGet()
        {
            using (var context = new EStoreContext()) {
                categories = context.Categories.ToList();
            }
            return Page();
        }
        public async Task<IActionResult> OnPost(BusinessObject.Product product)
        {
            product.OrderDetails = null;
            product.Category = null;
            var jsonContent = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(ProductApiUrl, jsonContent);
            return Redirect("/Product/Index");
        }
    }
}
