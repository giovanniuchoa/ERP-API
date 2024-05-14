using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Services;
using CarQuery__Test.Services;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<Car> GetAllCars()
        {
            var cars = _carService.GetAllCars();
            return cars;
        }

        [HttpGet("{id}")] //Get car by id
        public IEnumerable<Car> GetCar(int id)
        {
            var car = _carService.GetCarById(id);
            return car;
        }

        public IActionResult CreateCar([FromBody] Car car) //Create a new car
        {
            if (_carService.CreateCar(car))
            {
                return Ok(new { success = true, message = "Carro criado com sucesso." });
            }
            else
            {
                return BadRequest(new { success = false, message = "Erro ao criar o carro." });
            }
        }

        [HttpPut("{id}")] //Update a car
        public IEnumerable<Car> UpdateCar(int id, [FromBody]Car car)
        {
            var newCar = _carService.UpdateCar(id, car);
            return newCar;
        }

        [HttpDelete("{id}")] //Delete a car
        public IActionResult DeleteCar(int id)
        {
            if (_carService.DeleteCar(id))
            {
                return Ok(new { success = true, message = "Carro excluído com sucesso." });
            }
            else
            {
                return NotFound(new { success = false, message = "Carro não encontrado." });
            }
        }
    }
}
