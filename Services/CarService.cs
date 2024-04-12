using CarQuery__Test.Data;
using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarQuery__Test.Services
{
    public class CarService : BaseRepository, ICarService
    {

        public CarService(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Car> GetCarById(int id)
        {
            var car =  _context.Cars.Find(id);
            yield return car;
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public bool CreateCar([FromBody]Car car)
        {
            try
            {
                _context.Cars.Add(car);
                _context.SaveChanges();
            }
            catch (Exception ex) 
            { 
                return false; 
            }

            return true;
        }

        public IEnumerable<Car> UpdateCar(int id, Car car)
        {
            var existingCar = _context.Cars.Find(id);

            existingCar.Name = car.Name;
            existingCar.Brand = car.Brand;
            existingCar.Year = car.Year;

            _context.SaveChanges();

           yield return car;
        }

        public bool DeleteCar(int id)
        {
            try
            {
                var existingCar = _context.Cars.Find(id);
                _context.Cars.Remove(existingCar);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
