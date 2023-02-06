using WebApiTest.Data;
using WebApiTest.Interfaces;
using WebApiTest.Services;

using Microsoft.EntityFrameworkCore;

namespace WebApiTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(); //checks the project for controllers and automatically add it
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MSSqlConnection"));//get from appsettings.json
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add services here
            // builder.Services.AddScoped<ITaskItemsService, TaskItemsApplicationContextService>();
            builder.Services.AddScoped<ITaskItemsService, TaskItemsMSSQLService>();
            builder.Services.AddScoped<IPriorityService, PriorityMSSQLService>();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}

