using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;


namespace ProductManagementWebClient.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HttpClient client = null;
        private string ProductApiUrl = "";
        private string CategoryApiUrl = "";
        public ProductsController() {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "http://localhost:5124/api/Products";
            CategoryApiUrl = "http://localhost:5124/api/Categories";

        }
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Product> listProducts = JsonSerializer.Deserialize<List<Product>>(strData,options);
            return View(listProducts);
        }

        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl + "/" + id + "/detail");
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Product products = JsonSerializer.Deserialize<Product>(strData, options);
            return View(products);
        }

        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product p)
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(p), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(ProductApiUrl, jsonContent);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Products/Index");
            }

            ModelState.AddModelError("", "Failed to create product.");
            return Redirect("/Products/Create");

        }

        public async Task<IActionResult> Edit(int id) {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl + "/" + id + "/detail");
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Product products = JsonSerializer.Deserialize<Product>(strData, options);
            return View(products);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            Product pro = new Product();
            pro.ProductId = id;
            pro.ProductName = collection["ProductName"];
            pro.UnitPrice = decimal.Parse(collection["UnitPrice"]);
            pro.UnitsInStock = int.Parse(collection["UnitsInStock"]);
            pro.CategoryId = int.Parse(collection["CategoryId"]);

            var jsonContent = new StringContent(JsonSerializer.Serialize(pro), Encoding.UTF8, "application/json");

            var response = await client.PutAsync(ProductApiUrl + "?id=" + id, jsonContent);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Products/Details/" + id);
            }

            ModelState.AddModelError("", "Failed to update product.");
            return Redirect("/Products/Edit/" + id);
        }

        public async Task<IActionResult> Delete(int id) {
            await client.DeleteAsync(ProductApiUrl + "?id=" + id);
            return Redirect("/Products/Index");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{

        //}

    }
}
