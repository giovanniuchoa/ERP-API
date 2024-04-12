using CarQuery__Test.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarQuery__Test.Domain.Services
{
    public interface ICarService
    {

        IEnumerable<Car> GetAllCars();
        IEnumerable<Car> GetCarById(int id);
        bool CreateCar(Car car);
        IEnumerable<Car> UpdateCar(int id, Car car);
        bool DeleteCar(int id);

    }


}
