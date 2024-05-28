using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarQuery__Test.Domain.Models
{
    public class Sale
    {
        [Key]
        [SwaggerIgnore]
        public int Id{ get; set; }

        [ForeignKey("Person")] 
        public int IdPerson { get; set; }
        [SwaggerIgnore]
        public Person? Person { get; set; }

        [ForeignKey("Car")]
        public int IdCar { get; set; }
        [SwaggerIgnore]
        public Car? Car { get; set; }

        [ForeignKey("Reseller")]
        public int IdReseller { get; set; }
        [SwaggerIgnore]
        public Reseller? Reseller { get; set; }

        public decimal Price { get; set; }      

    }
}

