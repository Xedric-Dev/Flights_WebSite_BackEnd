using Flights_Create_Book.Repo;
using Microsoft.AspNetCore.Mvc;
using Flights_Create_Book.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualBasic;

namespace Flights_Create_Book.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightRepository _flightRepository;

        public FlightsController(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight>>> GetAllFlightsAsync()
        {
            var allFlights = await _flightRepository.GetAllAsync();
            return Ok(allFlights);
        }

        [HttpPost]
        public async Task<ActionResult<Flight>> CreateFlights(Flight flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _flightRepository.CreateFlightAsync(flight);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = flight.Id }, flight);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetEmployeeById(int id)
        {
            var flight = await _flightRepository.GetByIdAsync(id);

            if (flight == null)
            {
                return NotFound();
            }
            return Ok(flight);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFlightAsync(int id, Flight flight)
        {
            if (id != flight.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid==false)
            {
                return BadRequest();
            }

            await _flightRepository.UpdateFlightAsync(flight);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = flight.Id }, flight);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFlightAsync(int id)
        {
            await _flightRepository.DeleteFlightAsync(id);
            return NoContent();
        }

    }
}
