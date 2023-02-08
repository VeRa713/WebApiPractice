namespace WebApiTest.Data;
using Microsoft.EntityFrameworkCore;
using WebApiTest.Models;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<Priority> Priorities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<TaskItem>()
            .HasOne(t => t.User)    //a task has one user
            .WithMany(u => u.TaskItems); //priority has many task items
    }
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
}
