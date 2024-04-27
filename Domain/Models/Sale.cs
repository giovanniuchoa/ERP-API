using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarQuery__Test.Domain.Models
{
    public class Sale
    {
        [Key]
        public int Id{ get; set; }

        [ForeignKey("Person")] 
        public int IdPerson { get; set; }   
        public Person? Person { get; set; }

        [ForeignKey("Car")]
        public int IdCar { get; set; }  
        public Car? Car { get; set; }

        [ForeignKey("Reseller")]
        public int IdReseller { get; set; } 
        public Reseller? Reseller { get; set; }

        public decimal Price { get; set; }      

    }
}

