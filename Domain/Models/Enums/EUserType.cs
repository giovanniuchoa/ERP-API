using System.ComponentModel;

namespace CarQuery__Test.Domain.Models.Enums
{
    /// <summary>
    /// Enumeração para representar os diferentes tipos de usuários.
    /// </summary>
    public enum EUserType : byte
    {
        /// <summary>
        /// Administrador.
        /// </summary>
        [Description("Administrator")]
        Administrator = 1,

        /// <summary>
        /// Vendedor.
        /// </summary>
        [Description("Seller")]
        Seller = 2,

        /// <summary>
        /// Cliente.
        /// </summary>
        [Description("Client")]
        Client = 3
    }
}
