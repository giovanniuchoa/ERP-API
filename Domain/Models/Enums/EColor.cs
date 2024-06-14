using System.ComponentModel;

namespace CarQuery__Test.Domain.Models.Enums
{
    /// <summary>
    /// Enumeração para representar as diferentes cores de carros.
    /// </summary>
    public enum EColor : byte
    {
        /// <summary>
        /// Cor prata.
        /// </summary>
        [Description("Silver")]
        Silver = 1,

        /// <summary>
        /// Cor azul.
        /// </summary>
        [Description("Blue")]
        Blue = 2,

        /// <summary>
        /// Cor verde.
        /// </summary>
        [Description("Green")]
        Green = 3,

        /// <summary>
        /// Cor preta.
        /// </summary>
        [Description("Black")]
        Black = 4,

        /// <summary>
        /// Cor branca.
        /// </summary>
        [Description("White")]
        White = 5,

        /// <summary>
        /// Cor amarela.
        /// </summary>
        [Description("Yellow")]
        Yellow = 6,

        /// <summary>
        /// Cor bege.
        /// </summary>
        [Description("Beige")]
        Beige = 7,

        /// <summary>
        /// Cor cinza.
        /// </summary>
        [Description("Grey")]
        Grey = 8,

        /// <summary>
        /// Cor rosa.
        /// </summary>
        [Description("Pink")]
        Pink = 9,

        /// <summary>
        /// Cor roxa.
        /// </summary>
        [Description("Purple")]
        Purple = 10,

        /// <summary>
        /// Cor marrom.
        /// </summary>
        [Description("Brown")]
        Brown = 11,

        /// <summary>
        /// Cor laranja.
        /// </summary>
        [Description("Orange")]
        Orange = 12,

        /// <summary>
        /// Cor violeta.
        /// </summary>
        [Description("Violet")]
        Violet = 13,

        /// <summary>
        /// Cor lilás.
        /// </summary>
        [Description("Lilac")]
        Lilac = 14,

        /// <summary>
        /// Cor índigo.
        /// </summary>
        [Description("Indigo")]
        Indigo = 15,

        /// <summary>
        /// Cor azul escuro.
        /// </summary>
        [Description("DarkBlue")]
        DarkBlue = 16,

        /// <summary>
        /// Cor vermelha.
        /// </summary>
        [Description("Red")]
        Red = 17
    }
}
