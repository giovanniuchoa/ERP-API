using CarQuery__Test.Domain.Models.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace CarQuery__Test.Domain.Models
{
    public class Person
    {
        [SwaggerIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly Birth {  get; set; }
        public ESex Sex { get; set; }
        public string Cpf { get; set; }

    }
}
