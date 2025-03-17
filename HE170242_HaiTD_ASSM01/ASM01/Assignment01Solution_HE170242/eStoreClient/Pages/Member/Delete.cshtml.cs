using BusinessObject;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eStoreClient.Pages.Member
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient client = null;
        private string MemberApiUrl = "";
        private string OrderApiUrl = "";
        private string OrderDetailApiUrl = "";
        public DeleteModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MemberApiUrl = "http://localhost:5288/api/Members";
            OrderApiUrl = "http://localhost:5288/api/Orders";
            OrderDetailApiUrl = "http://localhost:5288/api/OrderDetails";
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            List<BusinessObject.Order> orders = OrderDAO.GetListByMember((int)id);
            foreach (var order in orders) {
                await client.DeleteAsync(OrderDetailApiUrl + "/" + order.OrderId);
            }

            foreach (var order in orders)
            {
                await client.DeleteAsync(OrderApiUrl + "/" + order.OrderId + "/" + id);
            }

            await client.DeleteAsync(MemberApiUrl + "/" + id);
            return Redirect("/Member");
        }
    }
}
