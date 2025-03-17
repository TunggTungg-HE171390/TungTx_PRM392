using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryRepository c_repository = new CategoryRepository();
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategory() => c_repository.GetCategories();

        [HttpGet("{id}/detail")]
        public ActionResult<Category> GetCategoryById(int id) => c_repository.GetCategoryById(id);
    }
}
