using Microsoft.EntityFrameworkCore;

namespace WebAPI_OData_Demo2.Models
{
	public class BookStoreContext : DbContext
	{
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Press> Presss { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>().OwnsOne(b => b.Location);
		}
	}
}
