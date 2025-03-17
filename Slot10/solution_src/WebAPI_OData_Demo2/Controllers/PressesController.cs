using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using WebAPI_OData_Demo2.Models;

namespace WebAPI_OData_Demo2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PressesController : ControllerBase
	{
		private readonly BookStoreContext _context;
        public PressesController(BookStoreContext context)
        {
            _context = context;
			if (_context.Books.Count() == 0)
			{
				foreach (var b in DataSources.GetBooks()) {
					context.Books.Add(b);
					context.Presss.Add(b.Press);
				}
				context.SaveChanges();
			}
        }

		[EnableQuery, HttpGet]
		public IActionResult Get() => Ok(_context.Presss);


    }
}
