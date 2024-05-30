using CarQuery__Test.Domain.Models.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarQuery__Test.Domain.Models
{
    public class User
    {
        [Key]
        [SwaggerIgnore] 
        public int idUser { get; set; }
        public string nameUser { get; set; }
        public string cpf { get; set; } 
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; } 
        public DateOnly birth {  get; set; }
        public ESex sex { get; set; }
        public EUserType userType { get; set; }


    }
}
