using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace eStoreClient.Pages.Customer
{
    public class EditModel : PageModel
    {
        private readonly HttpClient client = null;
        private string MemberApiUrl = "";
        public BusinessObject.Member member = new BusinessObject.Member();
        public EditModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MemberApiUrl = "http://localhost:5288/api/Members";
        }
        public async Task<IActionResult> OnGet(int? id = 1)
        {
            HttpResponseMessage response = await client.GetAsync(MemberApiUrl + "/" + id);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            member = JsonSerializer.Deserialize<BusinessObject.Member>(strData, options);

            return Page();
        }

        public async Task<IActionResult> OnPost(BusinessObject.Member mem)
        {
            mem.Orders = null;
            var jsonContent = new StringContent(JsonSerializer.Serialize(mem), Encoding.UTF8, "application/json");

            var response = await client.PutAsync(MemberApiUrl + "/" + mem.MemberId, jsonContent);
            return Redirect("/Customer/Index");
        }
    }
}
