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

        [HttpGet]
        public IEnumerable<Car> Get()
        {
            var cars = _carService.GetCars();
            return cars;
        }

    }
}
