using Microsoft.EntityFrameworkCore;

namespace WebApp1
{
    public class TodoItemContext : DbContext
    {
        public TodoItemContext(DbContextOptions<TodoItemContext> options) : base(options) { }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
