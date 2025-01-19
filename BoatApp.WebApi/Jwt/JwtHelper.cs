using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BoatApp.WebApi.Jwt
{
    public static class JwtHelper
    {
        public static string JwtGenareteToken(JwtDto jwtDto)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtDto.SecretKey));

            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtClaimNames.Id, jwtDto.Id.ToString()),
                new Claim(JwtClaimNames.Email, jwtDto.Email),
                new Claim(JwtClaimNames.FirstName, jwtDto.FirstName),
                new Claim(JwtClaimNames.LastName, jwtDto.LastName),
                new Claim(JwtClaimNames.UserType, jwtDto.UserType.ToString()),

                new Claim(ClaimTypes.Role, jwtDto.UserType.ToString())
            };

            var ExpireTime = DateTime.UtcNow.AddMinutes(jwtDto.ExpireMinutes);

            var tokenDesc = new JwtSecurityToken(jwtDto.Issuer, jwtDto.Audience, claims, null, ExpireTime, signingCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenDesc);
            return token;


        }
    }
}
