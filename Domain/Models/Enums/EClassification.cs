using System.ComponentModel;

namespace CarQuery__Test.Domain.Models.Enums
{
    /// <summary>
    /// Enumeração para representar as classificações de medalhas.
    /// </summary>
    public enum EClassification : byte
    {
        /// <summary>
        /// Classificação ouro.
        /// </summary>
        [Description("Gold")]
        Gold = 1,

        /// <summary>
        /// Classificação prata.
        /// </summary>
        [Description("Silver")]
        Silver = 2,

        /// <summary>
        /// Classificação bronze.
        /// </summary>
        [Description("Bronze")]
        Bronze = 3
    }
}
