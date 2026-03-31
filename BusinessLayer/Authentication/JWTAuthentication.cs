using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BusinessLayer.DTOsPresentation.AuthDTOs;
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

        public TokenResponse GenerateToken(int userId, short role, string username)
        {
            


            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role.ToString())
            };

            
            var creds = new SigningCredentials(GenerateSymmetricKey(), SecurityAlgorithms.HmacSha256);

            
            var token = new JwtSecurityToken(
                issuer: _Issuer,
                audience: _Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
            );

            
            var accesstoken= _tokenHandler.WriteToken(token);


            var refreashtoken = GenerateRefreshToken();

            return new TokenResponse
            {

                AccessToken = accesstoken,
                RefreshToken = refreashtoken
            };

        }

        private static string GenerateRefreshToken()
        {
            var bytes = new byte[64];

            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);

            return Convert.ToBase64String(bytes);
        }

        

        
    }
}
