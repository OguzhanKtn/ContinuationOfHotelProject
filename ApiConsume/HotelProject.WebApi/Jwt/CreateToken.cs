using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace HotelProject.WebApi.Jwt
{
    public class CreateToken
    {
        public string TokenCreate()
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapiapiherzamanheryerdeenbuyukfener");
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken
                (
                issuer:"http://localhost",
                audience: "http://localhost",
                notBefore:DateTime.Now,
                expires:DateTime.Now.AddMinutes(30),
                signingCredentials:credentials
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

           return handler.WriteToken(token);
        }
    }
}
