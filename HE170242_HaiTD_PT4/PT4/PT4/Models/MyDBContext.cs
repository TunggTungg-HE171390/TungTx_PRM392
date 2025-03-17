using Microsoft.EntityFrameworkCore;

namespace PT4.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }
        #region DBSet
        public DbSet<Product> Products { get; set; }
        #endregion


    }
}
