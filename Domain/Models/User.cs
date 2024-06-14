using CarQuery__Test.Domain.Models.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarQuery__Test.Domain.Models
{
    /// <summary>
    /// Modelo de usuário com informações como nome, CPF, senha, email, telefone, data de nascimento, sexo e tipo de usuário.
    /// </summary>
    public class User
    {
        [Key]
        [SwaggerIgnore]
        public int idUser { get; set; }

        /// <summary>
        /// Nome do usuário.
        /// </summary>
        public string nameUser { get; set; }

        /// <summary>
        /// CPF do usuário.
        /// </summary>
        public string cpf { get; set; }

        /// <summary>
        /// Senha do usuário.
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// Email do usuário.
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Telefone do usuário.
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// Data de nascimento do usuário.
        /// </summary>
        public DateOnly birth { get; set; }

        /// <summary>
        /// Sexo do usuário.
        /// </summary>
        public ESex sex { get; set; }

        /// <summary>
        /// Tipo de usuário.
        /// </summary>
        public EUserType userType { get; set; }
    }
}
