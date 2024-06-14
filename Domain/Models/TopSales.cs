namespace CarQuery__Test.Domain.Models
{
    /// <summary>
    /// Representa informações resumidas de uma venda de carro.
    /// </summary>
    public class TopSales
    {
        /// <summary>
        /// Identificador da venda.
        /// </summary>
        public int IdSale { get; set; }

        /// <summary>
        /// Preço da venda.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Nome do vendedor responsável pela venda.
        /// </summary>
        public string NomeVendedor { get; set; }

        /// <summary>
        /// Modelo do carro vendido.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Marca do carro vendido.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Ano do carro vendido.
        /// </summary>
        public int Year { get; set; }
    }
}
