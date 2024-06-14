using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarQuery__Test.Domain.Models
{
    /// <summary>
    /// Modelo de venda com informações sobre o cliente, vendedor, carro, data de registro e preço.
    /// </summary>
    public class Sale
    {
        [Key]
        [SwaggerIgnore]
        public int idSale { get; set; }

        /// <summary>
        /// Id do cliente associado à venda.
        /// </summary>
        public int Fk_IdClient { get; set; }

        [ForeignKey(nameof(Fk_IdClient))]
        [SwaggerIgnore]
        public User? Client { get; set; }

        /// <summary>
        /// Id do vendedor associado à venda.
        /// </summary>
        public int Fk_IdSeller { get; set; }

        [ForeignKey(nameof(Fk_IdSeller))]
        [SwaggerIgnore]
        public User? Seller { get; set; }

        /// <summary>
        /// Id do carro associado à venda.
        /// </summary>
        public int Fk_IdCar { get; set; }

        [ForeignKey(nameof(Fk_IdCar))]
        [SwaggerIgnore]
        public Car? Car { get; set; }

        /// <summary>
        /// Data e hora do registro da venda.
        /// </summary>
        public DateTime DthRegister { get; set; }

        /// <summary>
        /// Preço da venda.
        /// </summary>
        public decimal price { get; set; }
    }
}
