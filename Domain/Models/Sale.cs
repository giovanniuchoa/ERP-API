using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarQuery__Test.Domain.Models
{
    public class Sale
    {
        [Key]
        [SwaggerIgnore]
        public int idSale{ get; set; }

        public int Fk_IdClient { get; set; }
        [ForeignKey(nameof(Fk_IdClient))]
        [SwaggerIgnore]
        public User? Client { get; set; }

        public int Fk_IdSeller { get; set; }
        [ForeignKey(nameof(Fk_IdSeller))]
        [SwaggerIgnore]
        public User? Seller { get; set; }

        public int Fk_IdCar { get; set; }
        [ForeignKey(nameof(Fk_IdCar))]
        [SwaggerIgnore]
        public Car? Car { get; set; }

        public int Fk_IdReseller { get; set; }
        [ForeignKey(nameof(Fk_IdReseller))]
        [SwaggerIgnore]
        public Reseller? Reseller { get; set; }

        public DateTime DthRegister { get; set; } 

        public decimal price { get; set; }      

    }
}

