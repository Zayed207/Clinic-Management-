using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLayer.Authentication
{
    public class JWTAuthentication
    {
        public string _Key { get; set; }
        public string _Audience { get; set; }
        public string _Issuer { get; set; }

        private readonly JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();

        public JWTAuthentication(string key, string audience, string issuer)
        {
            _Key = key;
            _Audience = audience;
            _Issuer = issuer;
        }

        private SymmetricSecurityKey GenerateSymmetricKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Key));

        public string GenerateToken(string userId, string role, string username)
        {
            //-1
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };

            //-2
            var creds = new SigningCredentials(GenerateSymmetricKey(), SecurityAlgorithms.HmacSha256);

            //-3
            var token = new JwtSecurityToken(
                issuer: _Issuer,
                audience: _Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
            );

            //-4
            return _tokenHandler.WriteToken(token);
        }

        public ClaimsPrincipal? VerifyToken(string token)
        {
            try
            {
                //-1
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = GenerateSymmetricKey(),
                    ValidateIssuer = true,
                    ValidIssuer = _Issuer,
                    ValidateAudience = true,
                    ValidAudience = _Audience,
                    ClockSkew = TimeSpan.Zero
                };

                //-2
                var principal = _tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                //-3
                if (validatedToken is JwtSecurityToken jwtToken &&
                    jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    return principal;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        public string RefreshToken(ClaimsPrincipal oldPrincipal)
        {
            var creds = new SigningCredentials(GenerateSymmetricKey(), SecurityAlgorithms.HmacSha256);
            var claims = oldPrincipal.Claims;

            var newToken = new JwtSecurityToken(
                issuer: _Issuer,
                audience: _Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: creds
            );

            return _tokenHandler.WriteToken(newToken);
        }
    }
}
