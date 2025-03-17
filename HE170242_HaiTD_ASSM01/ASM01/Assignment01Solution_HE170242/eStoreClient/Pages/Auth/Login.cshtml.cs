using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using eStoreAPI.Request;
using System.Security.Principal;

namespace eStoreClient.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly HttpClient client = null;
        private string AuthApiUrl = "";
        
        public LoginModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            AuthApiUrl = "http://localhost:5288/api/Auth";
        }
        public async Task<IActionResult> OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPost(string email, string password)
        {
            Console.WriteLine(email + " - " + password);
            var request = new
            {
                email = email,
                password = password
            };
            var jsonContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(AuthApiUrl, jsonContent);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var member = JsonSerializer.Deserialize<BusinessObject.Member>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                Console.WriteLine(member.Email);
                HttpContext.Session.SetInt32("memId", member.MemberId);
                if (member.MemberId == 0) { return Redirect("/Member"); }
                else return Redirect("/Customer/Index?id=" + member.MemberId);

            }
            Console.WriteLine(response.Content);
            return Page();
        }
    }
}
