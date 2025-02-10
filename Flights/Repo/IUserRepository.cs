using Flights_Create_Book.Models;

namespace Flights_Create_Book.Repo
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);

    }
}
