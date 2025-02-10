using Flights_Create_Book.Data;
using Flights_Create_Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Flights_Create_Book.Repo
{
    public class FlightRepository : IFlightRepository
    {

        private readonly AppDbContext _context;

        public FlightRepository (AppDbContext appDbcontext)
        {
            _context = appDbcontext;
        }

        public async Task CreateFlightAsync(Flight flight)
        {
            await _context.Flights.AddAsync(flight);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFlightAsync(int id)
        {
            var flightToDelete =await _context.Flights.FindAsync(id);
            if (flightToDelete == null)
            {
                throw new KeyNotFoundException($"Flight with Id {id} not found!");
            }
            else
            {
                _context.Flights.Remove(flightToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Flight>> GetAllAsync()
        {
            return await _context.Flights.ToListAsync();
        }

        public async Task<Flight> GetByIdAsync(int id)
        {
            return await _context.Flights.FindAsync(id);
        }

        public async Task<IEnumerable<Flight>?> GetByFiltersAsync(string from, string to, string fromDate, int passengersNum)
        {
            return await _context.Flights
                .Where(flight => flight.fromLocation == from)
                .Where(flight => flight.toLocation == to)
                .Where(flight => flight.fromDate == fromDate)
                .Where(flight => flight.passengerNumber > passengersNum)
                .ToListAsync();
        }

        public async Task UpdateFlightAsync(Flight flight)
        {
            _context.Flights.Update(flight);
            await _context.SaveChangesAsync();
        }
    }
}
