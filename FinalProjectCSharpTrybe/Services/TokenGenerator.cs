using FinalProjectCSharpTrybe.Models;
using FinalProjectCSharpTrybe.Properties;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinalProjectCSharpTrybe.Services
{
    public class TokenGenerator
    {
        /// <summary>
        /// This function is to Generate Token 
        /// </summary>
        /// <returns>A string, the token JWT</returns>
        public string Generate(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            user.Password = String.Empty;

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = AddClaims(user),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Nothing.MyVerySecretWord)),
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Expires = DateTime.Now.AddDays(1)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);


            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Function that adds the claims to the token
        /// </summary>
        /// <param name="user"> A user object value</param>
        /// <returns>Returns an object of type ClaimsIdentity</returns>
        private ClaimsIdentity AddClaims(User user)
        {
            var claims = new ClaimsIdentity();

            claims.AddClaim(new Claim("Id", user.Id.ToString()));
            claims.AddClaim(new Claim("Name", user.Name));
            claims.AddClaim(new Claim("Email", user.Email));

            return claims;

        }
    }
}
