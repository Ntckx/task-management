using Microsoft.EntityFrameworkCore;
using TaskManagement.Models;

namespace TaskManagement.data;

public class AppDbContext : DbContext
{
    // Constructor Dependency Injection
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<TaskItem> TaskItems
    {
        get; set;
    }
    public DbSet<Notification> Notifications { get; set; }

}