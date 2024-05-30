using System.ComponentModel;

namespace CarQuery__Test.Domain.Models.Enums
{
    public enum EUserType : byte
    {

        [Description("Administrator")]
        Administartor = 1,

        [Description("Seller")]
        Seller = 2,

        [Description("Client")]
        Client = 3

    }
}
