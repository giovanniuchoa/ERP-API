using CarQuery__Test.Authentication.Models;
using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Models.Enums;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace CarQuery__Test.Authentication.Services
{
    public static class TokenService
    {
        public static string GenerateToken(User user)
        {

            string role;

            if ((int)user.userType == 1)
            {
                role = "A";
            }
            else if ((int)user.userType == 2)
            {
                role = "S";
            }
            else if ((int)user.userType == 3)
            {
                role = "U";
            }
            else
            {
                role = "U";
            }


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.nameUser),
                    new Claim(ClaimTypes.Email, user.email),
                    new Claim(ClaimTypes.Role, role), // tipo usuario
                    new Claim(ClaimTypes.NameIdentifier, user.idUser.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public static Task<string> GenerateTokenAsync(User user)
        {
            return Task.Run(() => GenerateToken(user));
        }

        public static string GetValueFromClaim(IIdentity identity, string field)
        {
            var claims = identity as ClaimsIdentity;

            return claims.FindFirst(field).Value;
        }
    }
}
