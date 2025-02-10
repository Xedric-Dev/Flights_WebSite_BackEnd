using Flights_Create_Book.Data;
using Flights_Create_Book.Repo;
using Microsoft.EntityFrameworkCore;

namespace Flights_Create_Book
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("FlightsDb"));

            builder.Services.AddDbContext<UserDbContext>(options => options.UseInMemoryDatabase("UsersDb"));

            builder.Services.AddScoped<IFlightRepository, FlightRepository>();

            builder.Services.AddScoped<IUserRepository,UserRepository>();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCors", builder =>
                {
                    builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
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
