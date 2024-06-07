using CarQuery__Test.Domain.Models.Enums;

namespace CarQuery__Test.Domain.Models
{
    public class UserAuthenticateResponse
    {
        public UserAuthenticateResponse(User user, string token)
        {
            this.IdUser = user.idUser;
            this.NameUser = user.nameUser;
            this.UserType = user.userType;
            this.Token = token;
        }
        public int IdUser { get; set; }
        public string NameUser { get; set; }
        public EUserType UserType { get; set; }
        public string Token { get; set; }
    }
}
