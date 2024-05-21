using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Services;
using CarQuery__Test.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarQuery__Test.Controllers
{

    [Route("Car")]
    public class CarController : ControllerBase
    {

        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet] //Get all cars
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
                // Log the exception here
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }


        [HttpGet("{id}")] //Get car by id
        public async Task<IActionResult> GetCarById(int id)
        {
            try
            {
                var car = await _carService.GetCarByIdAsync(id);
                if (car == null)
                {
                    return NotFound(new { message = "Carro não encontrado." });
                }
                return Ok(car);
            }
            catch (Exception ex)
            {
                // Log the exception details here if needed
                return StatusCode(500, new { message = "Erro interno do servidor.", details = ex.Message });
            }
        }



        [HttpPost] //Create a car
        public async Task<IActionResult> CreateCar([FromBody] Car car)
        {
            try
            {
                var createdCar = await _carService.CreateCarAsync(car);
                return CreatedAtAction(nameof(GetCarById), new { id = createdCar.Id }, createdCar);
            }
            catch (DbUpdateException ex)
            {
                // Log the error (uncomment ex variable name and write a log.)
                return StatusCode(500, $"Internal server error: {ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                // Log the error (uncomment ex variable name and write a log.)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }


        [HttpPut("{id}")] //Update a car
        public async Task<IActionResult> UpdateCar(int id, [FromBody] Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedCar = await _carService.UpdateCarAsync(id, car);
                if (updatedCar == null)
                {
                    return NotFound(new { message = "Carro não encontrado." });
                }
                return Ok(updatedCar);
            }
            catch (Exception ex)
            {
                // Log the exception details here if needed
                return StatusCode(500, new { message = "Erro interno do servidor.", details = ex.Message });
            }
        }


        [HttpDelete("{id}")] //Delete a car

        public async Task<IActionResult> DeleteCar(int id)
        {
            try
            {
                var result = await _carService.DeleteCarAsync(id);
                if (result == false)
                {
                    return NotFound(new { message = "Carro não encontrado." });
                }
                return Ok(new { message = "Carro deletado." });
            }
            catch (Exception ex)
            {
                // Log the exception details here if needed
                return StatusCode(500, new { message = "Erro interno do servidor.", details = ex.Message });
            }
        }
    }
}
