using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using PT4.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PT4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyDBContext _context;
        public ProductsController(MyDBContext context)
        {
            _context = context;
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Products.AsQueryable());
        }
    }
}
