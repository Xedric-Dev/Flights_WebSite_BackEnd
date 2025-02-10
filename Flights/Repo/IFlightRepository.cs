using Flights_Create_Book.Models;

namespace Flights_Create_Book.Repo
{
    public interface IFlightRepository
    {

        Task<IEnumerable<Flight>> GetAllAsync();
        Task<Flight> GetByIdAsync(int id);
        Task<IEnumerable<Flight>?> GetByFiltersAsync(string from, string to, string fromDate, int passengersNum);
        Task CreateFlightAsync(Flight flight);
        Task UpdateFlightAsync(Flight flight);
        Task DeleteFlightAsync(int id);
    }
}
