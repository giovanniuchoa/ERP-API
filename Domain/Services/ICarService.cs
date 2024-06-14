using CarQuery__Test.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarQuery__Test.Domain.Services
{
    public interface ICarService
    {

        Task<IEnumerable<Car>> GetAllCarsAsync();
        Task<Car> GetCarByIdAsync(int id);
        Task<Return> CreateCarAsync(Car car);
        Task<Return> UpdateCarAsync(int id, Car car);
        Task<bool> DeleteCarAsync(int id);


    }


}
