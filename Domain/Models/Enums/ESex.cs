using System.ComponentModel;

namespace CarQuery__Test.Domain.Models.Enums
{
    /// <summary>
    /// Enumeração para representar os diferentes sexos.
    /// </summary>
    public enum ESex : byte
    {
        /// <summary>
        /// Sexo masculino.
        /// </summary>
        [Description("Male")]
        Male = 1,

        /// <summary>
        /// Sexo feminino.
        /// </summary>
        [Description("Female")]
        Female = 2
    }
}
