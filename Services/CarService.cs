using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Services;

namespace CarQuery__Test.Services
{
    public class CarService : ICarService
    {
        public IEnumerable<Car> GetCars()
        {
            return Enumerable.Range(1, 5).Select(index => new Car
            {
                Id = Random.Shared.Next(0, 50),
                Name = "Ranger",
                Brand = "Ford",
                Year = Random.Shared.Next(1900, 2024)
                
            })
            .ToArray();
        }
    }
}
