using CarQuery__Test.Authentication.Services;
using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Services;
using CarQuery__Test.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        /// <summary>
        /// Autentica um usuário.
        /// </summary>
        /// <param name="userAuthenticated">Credenciais do usuário.</param>
        /// <returns>Token JWT se a autenticação for bem-sucedida.</returns>
        /// <response code="200">Usuário autenticado com sucesso.</response>
        /// <response code="400">Usuário ou senha incorretos.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("authenticate"), AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Authenticate(UserAuthenticateRequest userAuthenticated)
        {
            try
            {
                var login = await _userService.AuthenticateAsync(userAuthenticated);

                if (login == null)
                {
                    return BadRequest("Incorrect User or Password");
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

        /// <summary>
        /// Obtém todos os usuários.
        /// </summary>
        /// <returns>Uma lista de usuários.</returns>
        /// <response code="200">Retorna a lista de usuários.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="404">Nenhum usuário encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<User>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
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

        /// <summary>
        /// Obtém um usuário pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        /// <returns>O usuário correspondente ao ID.</returns>
        /// <response code="200">Retorna o usuário solicitado.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="404">Usuário não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
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

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        /// <param name="user">O objeto usuário a ser criado.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
        /// <response code="200">Usuário criado com sucesso.</response>
        /// <response code="400">Formato JSON inválido.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            string role = TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.Role);

            if (role.Equals("S") || role.Equals("U"))
            {
                return BadRequest("User without access");
            }

            try
            {
                Return createdUser = await _userService.CreateUserAsync(user);
                if (createdUser.Error == true)
                {
                    return BadRequest(createdUser.Message);
                }
                else
                {
                    return Ok("User created successfully.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        /// <param name="id">ID do usuário a ser atualizado.</param>
        /// <param name="user">O objeto usuário com as novas informações.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
        /// <response code="200">Usuário atualizado com sucesso.</response>
        /// <response code="400">Formato JSON inválido.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="404">Usuário não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            string role = TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.Role);

            if (role.Equals("S") || role.Equals("U"))
            {
                return BadRequest("User without access");
            }

            try
            {
                Return updatedUser = await _userService.UpdateUserAsync(id, user);
                if (updatedUser.Error == true)
                {
                    return NotFound(updatedUser.Message);
                }
                return Ok(updatedUser.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Exclui um usuário pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário a ser excluído.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
        /// <response code="200">Usuário excluído com sucesso.</response>
        /// <response code="400">Formato JSON inválido.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="404">Usuário não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            string role = TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.Role);

            if (role.Equals("S") || role.Equals("U"))
            {
                return BadRequest("User without access");
            }

            try
            {
                var result = await _userService.DeleteUserAsync(id);
                if (result == false)
                {
                    return NotFound("User not found.");
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
