using Microsoft.EntityFrameworkCore;

namespace PT1
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }
        public DbSet<Student> TodoItems { get; set; }
    }
}
