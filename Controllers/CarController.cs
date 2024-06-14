using CarQuery__Test.Authentication.Services;
using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Services;
using CarQuery__Test.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarQuery__Test.Controllers
{
    /// <summary>
    /// Controller para gerenciamento de carros.
    /// </summary>
    [Route("Car")]
    [Authorize]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        /// <summary>
        /// Obtém todos os carros.
        /// </summary>
        /// <returns>Uma lista de carros.</returns>
        /// <response code="200">Retorna a lista de carros.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="404">Se nenhum carro for encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Car>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllCars()
        {
            try
            {
                var cars = await _carService.GetAllCarsAsync();
                if (cars == null || !cars.Any())
                {
                    return NotFound("No cars found.");
                }
                return Ok(cars);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtém um carro pelo ID.
        /// </summary>
        /// <param name="id">ID do carro.</param>
        /// <returns>O carro correspondente ao ID.</returns>
        /// <response code="200">Retorna o carro solicitado.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="404">Se o carro não for encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Car), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetCarById(int id)
        {
            try
            {
                var car = await _carService.GetCarByIdAsync(id);
                if (car == null)
                {
                    return NotFound($"Car not found.");
                }
                return Ok(car);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Cria um novo carro.
        /// </summary>
        /// <param name="car">O objeto carro a ser criado.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
        /// <response code="200">Carro criado com sucesso.</response>
        /// <response code="400">Formato JSON inválido.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateCar([FromBody] Car car)
        {
            string role = TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.Role);

            if (role.Equals("S") || role.Equals("U"))
            {
                return BadRequest($"User without access");
            }

            try
            {
                Return createdCar = await _carService.CreateCarAsync(car);
                if (createdCar.Error == true)
                {
                    return BadRequest(createdCar.Message);
                }
                else
                {
                    return Ok($"Car created successfully.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Atualiza um carro existente.
        /// </summary>
        /// <param name="id">ID do carro a ser atualizado.</param>
        /// <param name="car">O objeto carro com as novas informações.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
        /// <response code="200">Carro atualizado com sucesso.</response>
        /// <response code="400">Formato JSON inválido.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="404">Carro não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] Car car)
        {
            string role = TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.Role);

            if (role.Equals("S") || role.Equals("U"))
            {
                return BadRequest($"User without access");
            }

            try
            {
                Return updatedCar = await _carService.UpdateCarAsync(id, car);
                if (updatedCar.Error == true)
                {
                    return NotFound(updatedCar.Message);
                }
                return Ok(updatedCar.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Exclui um carro pelo ID.
        /// </summary>
        /// <param name="id">ID do carro a ser excluído.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
        /// <response code="200">Carro excluído com sucesso.</response>
        /// <response code="400">Formato JSON inválido.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="404">Carro não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteCar(int id)
        {
            string role = TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.Role);

            if (role.Equals("S") || role.Equals("U"))
            {
                return BadRequest($"User without access");
            }

            try
            {
                var result = await _carService.DeleteCarAsync(id);
                if (result == false)
                {
                    return NotFound($"Car not found.");
                }
                return Ok($"Car ID ({id}) deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
