using Flights_Create_Book.Data;
using Flights_Create_Book.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Flights_Create_Book
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("Database");

            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(connectionString, o => o.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "flights")));

            builder.Services.AddDbContext<UserDbContext>(
                options => options.UseSqlServer(connectionString, o => o.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "user")));

            builder.Services.AddScoped<IFlightRepository, FlightRepository>();

            builder.Services.AddScoped<IUserRepository,UserRepository>();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCors", builder =>
                {
                    builder.WithOrigins("http://localhost:4200","https://xedric-dev.github.io").AllowAnyHeader().AllowAnyMethod();
                });
            });

            var app = builder.Build();

            app.UseCors("MyCors");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
                        c.RoutePrefix = string.Empty;
                    });
            }

            app.MapControllers();

            app.Run();
        }
    }
}
