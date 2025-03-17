using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository p_repository = new ProductRepository();
        private ICategoryRepository c_repository = new CategoryRepository();

        //GETL api/Products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() => p_repository.GetProducts();

        [HttpGet("{id}/detail")]
        public ActionResult<Product> GetProductsByid(int id) => p_repository.GetProductById(id);

        //POST: ProductsController/Products
        [HttpPost]
        public IActionResult PostProduct(Product p)
        {
            p_repository.SaveProduct(p);
            return NoContent();
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id) {
            var p = p_repository.GetProductById(id);
            if ( p == null)
            {
                return NotFound();
            }
            p_repository.DeleteProduct(p);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateProduct(int id, Product p)
        {
            var pTmp = p_repository.GetProductById(id);
            if (p == null) return NotFound();
            var cTmp = c_repository.GetCategoryById(p.CategoryId);
            if (cTmp == null) return NotFound();

            pTmp.ProductName = p.ProductName;
            pTmp.UnitPrice = p.UnitPrice;
            pTmp.UnitsInStock = p.UnitsInStock;
            pTmp.CategoryId = p.CategoryId;
            p_repository.UpdateProduct(pTmp);
            return NoContent();
        }
    }
}
