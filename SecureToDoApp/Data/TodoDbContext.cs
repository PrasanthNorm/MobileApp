using Microsoft.EntityFrameworkCore;
using SecureToDoApp.Model;

namespace TodoSecureApp.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
