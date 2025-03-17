using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace eStoreClient.Pages.Member
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient client = null;
        private string MemberApiUrl = "";
        public CreateModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MemberApiUrl = "http://localhost:5288/api/Members";
        }
        public async Task<IActionResult> OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost(BusinessObject.Member mem)
        {
            mem.Orders = null;
            var jsonContent = new StringContent(JsonSerializer.Serialize(mem), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(MemberApiUrl, jsonContent);
            return Redirect("/Member");
        }
    }
}
