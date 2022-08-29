using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TSK.Model;

namespace TSK.Security
{
    public class TokenProvider
    {
        public Token GenerateToken(int id, string username, string key, string validIssuer, string validAudience)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var minutesTillExpires = 5;
            var tokenOptions = new JwtSecurityToken(
                issuer: validIssuer,
                audience: validAudience,
                claims: new List<Claim>() { new Claim("ID", id.ToString()), new Claim("Username", username) },
                expires: DateTime.Now.AddMinutes(minutesTillExpires),
                signingCredentials: signingCredentials
            );;

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new Token
            {
                AccessToken = tokenString,
                MinutesTillExpires = minutesTillExpires
            };
        }
    }
}