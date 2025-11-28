using Microsoft.EntityFrameworkCore;
using Entities;

namespace Infratructure;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
}