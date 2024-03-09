using CarQuery__Test.Domain.Models;

namespace CarQuery__Test.Domain.Services
{
    public interface ICarService
    {

        IEnumerable<Car> GetAllCars();
        IEnumerable<Car> GetCarById(int id);

    }
}
