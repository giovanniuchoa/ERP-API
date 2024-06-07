using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Services;
using CarQuery__Test.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarQuery__Test.Controllers
{

    [Route("User")]
    [Authorize]
    public class UserController : ControllerBase 
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate"), AllowAnonymous] //Authenticate user
        public async Task<IActionResult> Authenticate(UserAuthenticateRequest userAuthenticated)
        {

            try
            {
                var login = await _userService.AuthenticateAsync(userAuthenticated);

                if (login == null)
                {
                    return BadRequest($"Incorrect User or Password");
                }
                else
                {
                    return Ok(login);
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
            
        }

        [HttpGet] //Get all users
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                if (users == null || !users.Any())
                {
                    return NotFound("No user found.");
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("{id}")] //Get user by id
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound($"User not found.");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost] //Create a new user
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                var createdUser = await _userService.CreateUserAsync(user);
                if (createdUser == null)
                {
                    return BadRequest("Invalid JSON format");
                }
                else
                {
                    return Ok($"User created successfully.");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")] //Update a user
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {

            try
            {
                var updatedUser = await _userService.UpdateUserAsync(id, user);
                if (updatedUser == null)
                {
                    return NotFound($"Failed to update user.");
                }
                return Ok($"User updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")] //Delete a user
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var result = await _userService.DeleteUserAsync(id);
                if (result == false)
                {
                    return NotFound($"User not found.");
                }
                return Ok($"User ID ({id}) deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

    
}
