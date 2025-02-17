using Microsoft.EntityFrameworkCore;
using Flights_Create_Book.Models;

namespace Flights_Create_Book.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("flights");
        }
    }
}
