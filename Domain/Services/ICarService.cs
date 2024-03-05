using CarQuery__Test.Domain.Models;

namespace CarQuery__Test.Domain.Services
{
    public interface ICarService
    {

        IEnumerable<Car> GetCars();

    }
}
