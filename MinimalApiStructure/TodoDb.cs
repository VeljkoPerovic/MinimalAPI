using Microsoft.EntityFrameworkCore;

namespace MinimalApiStructure
{
    class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options) : base(options) { }

        public DbSet<Todo> Todos => Set<Todo>();


    }
}
