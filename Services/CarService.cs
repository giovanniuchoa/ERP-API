using CarQuery__Test.Data;
using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace CarQuery__Test.Services
{
    public class CarService : BaseRepository, ICarService
    {

        public CarService(AppDbContext context) : base(context) 
        {
        }

        public static Car ValidateCar(Car car)
        {

            if (car != null && !string.IsNullOrEmpty(car.model) && !string.IsNullOrEmpty(car.brand) && car.year != 0
                && car.color != 0 && car.price != 0)
            {
                return car;
            }
            else
            {
                return null;
            }
        }


        public async Task<Car> CreateCarAsync(Car car)
        {

            try
            {

                var ret = ValidateCar(car);

                if (ret != null)
                {
                _context.Cars.Add(car);
                await _context.SaveChangesAsync();
                return car;
                } else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
                
            }
        }


        public async Task<bool> DeleteCarAsync(int id) 
        {
            try
            {
                var carToDelete = await _context.Cars.FindAsync(id);
                if (carToDelete == null)
                {
                    return false;
                }

                _context.Cars.Remove(carToDelete);
                await _context.SaveChangesAsync();
                return true; 
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir o carro.", ex);
            }
        }


        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _context.Cars.ToListAsync();

        }


        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }


        public async Task<Car> UpdateCarAsync(int id, Car car)
        {

            var ret = ValidateCar(car);
            var existingCar = await _context.Cars.FindAsync(id);

            if (ret == null)
            {
                return null;
            } 
            else if (existingCar == null)
            {
                return null;
            }
            else
            {
                existingCar.model = car.model;
                existingCar.brand = car.brand;
                existingCar.year = car.year;
                existingCar.price = car.price;
                existingCar.color = car.color;

                _context.Cars.Update(existingCar);
                await _context.SaveChangesAsync();

                return car;
            }

        }

    }
}
