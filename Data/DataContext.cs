namespace WebApiTest.Data;
using Microsoft.EntityFrameworkCore;
using WebApiTest.Models;

public class DataContext : DbContext
{
    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<Priority> Priorities { get; set; }
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
}
