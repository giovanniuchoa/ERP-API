using Swashbuckle.AspNetCore.Annotations;
using CarQuery__Test.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarQuery__Test.Domain.Models
{
    /// <summary>
    /// Model de carro com os valores: model, year, color, price, and brand.
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Id do carro.
        /// </summary>
        [Key]
        [SwaggerIgnore]
        public int idCar { get; set; }

        /// <summary>
        /// Modelo do carro.
        /// </summary>
        public string model { get; set; }

        /// <summary>
        /// Ano de fabricação do carro.
        /// </summary>
        public int year { get; set; }

        /// <summary>
        /// Cor do carro.
        /// </summary>
        public EColor color { get; set; }

        /// <summary>
        /// Preço do carro.
        /// </summary>
        public decimal price { get; set; }

        /// <summary>
        /// Marca do carro (fabricante).
        /// </summary>
        public string brand { get; set; }
    }
}
