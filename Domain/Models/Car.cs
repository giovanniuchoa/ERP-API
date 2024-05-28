using Swashbuckle.AspNetCore.Annotations;

namespace CarQuery__Test.Domain.Models
{
    public class Car
    {
        [SwaggerIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }

    }
}
