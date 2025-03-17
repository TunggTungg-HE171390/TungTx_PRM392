namespace WebAPI_COntentNegotiation.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public string BlogDesription  { get; set; }
        public List<BlogPost> BlogPosts { get; set; }
        public Blog() => BlogPosts = new List<BlogPost>();
    }
}
