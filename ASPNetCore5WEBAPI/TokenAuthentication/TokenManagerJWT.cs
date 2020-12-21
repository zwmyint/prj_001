using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ASPNetCore5WEBAPI.TokenAuthentication
{
    public interface ITokenManagerJWT
    {
        bool Authenticate(string userName, string password);
        string NewToken();
        ClaimsPrincipal VerifyToken(string token);
    }

    public class TokenManagerJWT : ITokenManagerJWT
    {
        private JwtSecurityTokenHandler tokenHandler;
        private byte[] secretKey;

        public TokenManagerJWT()
        {
            tokenHandler = new JwtSecurityTokenHandler();
            secretKey = Encoding.ASCII.GetBytes("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz"); // 32 char
        }

        //

        public bool Authenticate(string userName, string password)
        {
            if (!string.IsNullOrWhiteSpace(userName) &&
                !string.IsNullOrWhiteSpace(password) &&
                userName.ToLower() == "admin" &&
                password == "password")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string NewToken()
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, "zaw win myint")}),
                Expires = DateTime.UtcNow.AddMinutes(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtString = tokenHandler.WriteToken(token);

            return jwtString;

        }

        public ClaimsPrincipal VerifyToken(string token)
        {
            
            var claims = tokenHandler.ValidateToken(token, 
                new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return claims;

        }

        //
    }
}