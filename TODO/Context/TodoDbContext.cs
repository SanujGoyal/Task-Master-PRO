using Microsoft.EntityFrameworkCore;
using TODO.Models;

namespace TODO.Context
{
    public class TodoDbContext : DbContext
    {

        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {

        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Tasks> Tasks { get; set; }

    }
}
