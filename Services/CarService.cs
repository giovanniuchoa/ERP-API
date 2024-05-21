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

        public async Task<Car> CreateCarAsync(Car car)
        {
            try
            {
                _context.Cars.Add(car);
                await _context.SaveChangesAsync();
                return car;
            }
            catch (DbUpdateException ex)
            {
                // Log the error (uncomment ex variable name and write a log.)
                Console.WriteLine($"An error occurred while saving the entity changes: {ex.InnerException?.Message}");
                throw; // Re-throw the exception to handle it in the controller
            }
        }


        public async Task<bool> DeleteCarAsync(int id) 
        {
            try
            {
                var carToDelete = await _context.Cars.FindAsync(id);
                if (carToDelete == null)
                {
                    return false; // Retorna false se o carro não for encontrado
                }

                _context.Cars.Remove(carToDelete);
                await _context.SaveChangesAsync();
                return true; // Retorna true se a exclusão for bem-sucedida
            }
            catch (Exception ex)
            {
                // Você pode registrar a exceção ou lançá-la novamente se desejar
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
            var existingCar = await _context.Cars.FindAsync(id);
            if (existingCar == null)
            {
                return null;
            }

            existingCar.Name = car.Name;
            existingCar.Brand = car.Brand;
            existingCar.Year = car.Year;

            _context.Cars.Update(existingCar);
            await _context.SaveChangesAsync();

            return existingCar;
        }

    }
}
