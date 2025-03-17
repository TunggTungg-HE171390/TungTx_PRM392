using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _proRepo = new ProductRepository();
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = _proRepo.GetAll();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = _proRepo.Get(id);
            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post(BusinessObject.Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            product.Category = null;
            product.OrderDetails = null;
            _proRepo.Add(product);
            return Ok(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BusinessObject.Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_proRepo.Get(id) == null) return NotFound();
            product.ProductId = id;
            _proRepo.Update(product);
            return Ok(product);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_proRepo.Get(id) == null) return NotFound();
            _proRepo.Delete(id);
            return Ok();
        }
    }
}
