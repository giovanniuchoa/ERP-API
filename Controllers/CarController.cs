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
                    return NotFound($"Car not found.");
                }
                return Ok(car);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        [HttpPost] //Create a car
        public async Task<IActionResult> CreateCar([FromBody] Car car)
        {
            try
            {
                var createdCar = await _carService.CreateCarAsync(car);
                if (createdCar == null)
                {
                    return BadRequest("Invalid JSON format");
                } else
                {
                    return Ok($"Car created successfully.");
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPut("{id}")] //Update a car
        public async Task<IActionResult> UpdateCar(int id, [FromBody] Car car)
        {

            try
            {
                var updatedCar = await _carService.UpdateCarAsync(id, car);
                if (updatedCar == null)
                {
                    return NotFound($"Failed to update car.");
                }
                return Ok($"Car updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
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
