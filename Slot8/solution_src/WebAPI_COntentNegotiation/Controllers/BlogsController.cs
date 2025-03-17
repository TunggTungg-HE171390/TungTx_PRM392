using Microsoft.AspNetCore.Mvc;
using WebAPI_COntentNegotiation.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_COntentNegotiation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        // GET: api/<BlogsController>
        [HttpGet]
        public IActionResult Get()
        {
            var blogs = new List<Blog>();
            var blogPosts = new List <BlogPost>();
            blogPosts.Add(new BlogPost {
                BlogPostId = 1,
                Title = "Lập trình c#",
                MetaDescription = " C# là ngôn ngữ lâp trình cấp cao" +
                "được ưa chuộng trên toàn thế giới...",
                IsPublished = true
            });
            blogPosts.Add(new BlogPost
            {
                BlogPostId = 2,
                Title = "Lập trình c#",
                MetaDescription = " C# là ngôn ngữ lâp trình cấp cao" +
                "được ưa chuộng trên toàn thế giới...",
                IsPublished = true
            });
            blogPosts.Add(new BlogPost
            {
                BlogPostId = 3,
                Title = "Lập trình PHP",
                MetaDescription = "PHP là ngôn ngữ lập trình web server-side",
                IsPublished = true
            });

            blogs.Add(new Blog
            {
                BlogId = 1,
                BlogName = "Blog ngôn ngữ lập trình",
                BlogDesription = "Blog này chuyên viết các bài viết về ngôn ngữ lập trình",
                BlogPosts = blogPosts
            });
            return Ok(blogs);
        }

        // GET api/<BlogsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BlogsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BlogsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BlogsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
