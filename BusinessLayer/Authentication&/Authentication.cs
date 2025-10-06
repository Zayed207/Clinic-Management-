using BusinessLayer.Authentecation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.Authentecation
{
    public class Authentication
    {
       
        
    }

}

public class JWTAuthentication
{
    public string _Key { get; set; }
    public string _Audience { get; set; }
    public string _Issuer { get; set; }

    public JWTAuthentication(string key, string audience, string issuer)
    {
        _Key = key;
        _Audience = audience;
        _Issuer = issuer;
    }
    

    public SymmetricSecurityKey GenerateSymmetricKey(string Key)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
    }

    public string GenerateToken(string userId, string role,string username)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
        };

        var key = GenerateSymmetricKey(_Key);
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _Issuer,
            audience: _Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(12),
            signingCredentials: creds
        );

        return  new JwtSecurityTokenHandler().WriteToken(token);



    }
    public string GenerateRefreshToken()
    {
        return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
    }


}
