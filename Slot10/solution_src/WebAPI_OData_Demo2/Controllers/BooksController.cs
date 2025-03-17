using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using WebAPI_OData_Demo2.Models;

namespace WebAPI_OData_Demo2.Controllers
{
	//[Route("api/[controller]")]
	//[ApiController]
	public class BooksController : ODataController //ControllerBase
	{
		private readonly BookStoreContext _context;
		public BooksController(BookStoreContext context)
		{
			_context = context;
			if (context.Books.Count() == 0)
			{
				foreach (var b in DataSources.GetBooks())
				{
					context.Books.Add(b);
					context.Presss.Add(b.Press);
				}
				context.SaveChanges();
			}
		}
		[EnableQuery(PageSize = 1), HttpGet]
		public IActionResult Get()
		{
			return Ok(_context.Books);
		}

		[EnableQuery, HttpPost]
		public IActionResult Post([FromBody] Book book)
		{
			_context.Books.Add(book);
			_context.SaveChanges();
			return Created("Get", book);
		}

		[EnableQuery, HttpDelete("{id}")]
		public IActionResult Delete([FromBody] int id)
		{
			var b = _context.Books.FirstOrDefault(b => b.Id == id);
			if(b == null)
			{
				return NotFound();
			}
			_context.Books.Remove(b);
			_context.SaveChanges();
			return NoContent();
		}

	}
}
