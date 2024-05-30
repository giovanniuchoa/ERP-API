using Swashbuckle.AspNetCore.Annotations;
using CarQuery__Test.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarQuery__Test.Domain.Models
{
    public class Car
    {
        [Key]
        [SwaggerIgnore]
        public int idCar { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public EColor color { get; set; }
        public decimal price { get; set; }
        public string brand { get; set; }

    }
}
