using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eStoreClient.Pages.Member
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = null;
        private string MemberApiUrl = "";
        public List<BusinessObject.Member> listMember = new List<BusinessObject.Member>();
        public IndexModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MemberApiUrl = "http://localhost:5288/api/Members";
        }
        public async Task<IActionResult> OnGet()
        {
            HttpResponseMessage response = await client.GetAsync(MemberApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            listMember = JsonSerializer.Deserialize<List<BusinessObject.Member>>(strData, options);

            return Page();
        }
    }
}
