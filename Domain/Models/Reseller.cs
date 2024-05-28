using Swashbuckle.AspNetCore.Annotations;

namespace CarQuery__Test.Domain.Models
{
    public class Reseller
    {
        [SwaggerIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

    }
}
