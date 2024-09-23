using Microsoft.EntityFrameworkCore;

namespace ToDoList.API.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
}
