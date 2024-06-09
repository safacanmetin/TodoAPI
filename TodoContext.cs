using Microsoft.EntityFrameworkCore;
using TodoAPI.Models;

namespace TodoAPI
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TodoDatabase");
        }
    }
}
