using CarQuery__Test.Data;
using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Models.Enums;
using CarQuery__Test.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace CarQuery__Test.Services
{
    public class CarService : BaseRepository, ICarService
    {

        public CarService(AppDbContext context) : base(context) 
        {
        }

        public static Return ValidateCar(Car car)
        {

            Return ret = new Return();
            EColor carColor = car.color;

            if (car == null)
            {
                ret.Error = true;
                ret.Message = "Car null.";
                return ret;
            }

            if (string.IsNullOrEmpty(car.model))
            {
                ret.Error = true;
                ret.Message = "Car model is empty.";
                return ret;
            }

            if (string.IsNullOrEmpty(car.brand))
            {
                ret.Error = true;
                ret.Message = "Car brand is empty.";
                return ret;
            }

            if (car.year == 0)
            {
                ret.Error = true;
                ret.Message = "Invalid car year.";
                return ret;
            }

            if (car.price == 0)
            {
                ret.Error = true;
                ret.Message = "Invalid car price.";
                return ret;
            }

            if (!Enum.IsDefined(typeof(EColor), carColor))
            {
                ret.Error = true;
                ret.Message = "Invalid car color.";
                return ret;
            }

            ret.Success = true;
            ret.Message = "Car validated.";
            return ret;
        }


        public async Task<Return> CreateCarAsync(Car car)
        {

            try
            {

                Return ret = ValidateCar(car);

                if (ret.Success == true)
                {
                _context.Cars.Add(car);
                await _context.SaveChangesAsync();
                return ret;
                } else
                {
                    return ret;
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


        public async Task<Return> UpdateCarAsync(int id, Car car)
        {

            Return ret = ValidateCar(car);
            var existingCar = await _context.Cars.FindAsync(id);

            if (ret.Error == true)
            {
                return ret;
            } 
            else if (existingCar == null)
            {
                ret.Message = "No car found.";
                return ret;
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

                ret.Message = "Car ID " + id + " updated successfully.";
                return ret;
            }

        }

    }
}
