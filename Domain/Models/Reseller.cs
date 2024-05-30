using CarQuery__Test.Domain.Models.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace CarQuery__Test.Domain.Models
{
    public class Reseller
    {
        [Key]
        [SwaggerIgnore]
        public int idReseller { get; set; }
        public string nameReseller { get; set; }
        public string address { get; set; }
        public string brand { get; set; }
        public EClassification classification { get; set; }
    }
}
 