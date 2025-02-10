using Flights_Create_Book.Data;
using Flights_Create_Book.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Flights_Create_Book.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository (UserDbContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var userToDelete = await _context.Users.FindAsync(id);
            if (userToDelete == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found!");
            }
            else
            {
                _context.Users.Remove(userToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
