using Flights_Create_Book.Models;
using Flights_Create_Book.Repo;
using Microsoft.AspNetCore.Mvc;

namespace Flights_Create_Book.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsersController : ControllerBase
    {

            private readonly IUserRepository _userRepository;

            public UsersController(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<User>>> GetAllUsersAsync()
            {
                var allUsers = await _userRepository.GetAllAsync();
                return Ok(allUsers);
            }

            [HttpPost]
            public async Task<ActionResult<User>> CreateUsers(User user)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _userRepository.CreateUserAsync(user);
                return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<User>> GetUserById(int id)
            {
                var user = await _userRepository.GetByIdAsync(id);

                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }

            [HttpPut("{id}")]
            public async Task<ActionResult> UpdateuserAsync(int id, User user)
            {
                if (id != user.Id)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid == false)
                {
                    return BadRequest();
                }

                await _userRepository.UpdateUserAsync(user);
                return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult> DeleteFlightAsync(int id)
            {
                await _userRepository.DeleteUserAsync(id);
                return NoContent();
            }
    }
}
