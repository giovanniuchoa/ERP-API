﻿using CarQuery__Test.Domain.Models;
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

        [HttpPost] //Create a new car
        public bool CreateCar([FromBody]Car car)
        {
            bool result = _carService.CreateCar(car);
            return result;
        }

        [HttpPut("{id}")] //Update a car
        public IEnumerable<Car> UpdateCar(int id, [FromBody]Car car)
        {
            var newCar = _carService.UpdateCar(id, car);
            return newCar;
        }

        [HttpDelete("{id}")] //Delete a car
        public bool DeleteCar(int id)
        {
            bool result = _carService.DeleteCar(id);
            return result;
        }
    }
}
