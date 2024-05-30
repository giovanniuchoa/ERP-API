using System.ComponentModel;

namespace CarQuery__Test.Domain.Models.Enums
{
    public enum EColor : byte
    {

        [Description("White")]
        White = 1,

        [Description("Black")]
        Black = 2,

        [Description("Red")]
        Red = 3,

        [Description("Blue")]
        Blue = 4,

        [Description("Silver")]
        Silver = 5,

        [Description("Yellow")]
        Yellow = 6,

    }
}
