using Microsoft.EntityFrameworkCore;
public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}
    public DbSet<TodoItem> TodoItems { get; set;}
}