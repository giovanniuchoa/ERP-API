using System.ComponentModel;

namespace CarQuery__Test.Domain.Models.Enums
{
    public enum EClassification : byte
    {

        [Description("Gold")]
        Gold = 1,

        [Description("Silver")]
        Silver = 2,

        [Description("Bronze")]
        Bronze = 3


    }
}
