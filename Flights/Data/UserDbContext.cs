using Flights_Create_Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Flights_Create_Book.Data
{
    public class UserDbContext : DbContext
    {
            public DbSet<User> Users { get; set; }
            public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

             protected override void OnModelCreating(ModelBuilder modelBuilder)
             {
                 modelBuilder.HasDefaultSchema("user");
             }

    }
}
