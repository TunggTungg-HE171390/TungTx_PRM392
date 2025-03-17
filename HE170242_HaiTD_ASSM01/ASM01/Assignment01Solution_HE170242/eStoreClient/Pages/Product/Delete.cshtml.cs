using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;

namespace eStoreClient.Pages.Product
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient client = null;
        private string ProductApiUrl = "";
        public DeleteModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "http://localhost:5288/api/Products";
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            using (var context = new EStoreContext()) {
                List<OrderDetails> odd = context.OrderDetails.Where(o => o.ProductId == id).ToList();
                context.OrderDetails.RemoveRange(odd);
                await context.SaveChangesAsync();
            }
            await client.DeleteAsync(ProductApiUrl + "/" + id);
            return Redirect("/Product/Index");
        }
    }
}
