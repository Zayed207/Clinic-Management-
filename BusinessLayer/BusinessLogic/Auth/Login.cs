using Azure.Core;
using BusinessLayer.Authentication;
using BusinessLayer.DTOsPresentation.AuthDTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Org.BouncyCastle.Crypto.Generators;
using System.Threading.Tasks;
namespace BusinessLayer.BusinessLogic.Auth
{
    public class Login
    {
        private readonly UserServices _services;
        private readonly JWTAuthentication _jwt;

        public Login(UserServices services, JWTAuthentication jwt)
        {
            this._services = services;
            this._jwt = jwt;
        }

        public async Task<TokenResponse>LogIn(string username, string password)
        {
            var user =await _services.GetUserByUserName(username,password);

            if (user.Status ==ResultStatus.Success)
            {

                var token =  _jwt.GenerateToken(user.Data.UserID, user.Data.RoleID, user.Data.UserName);

                user.Data.RefreshTokenHash = _services.HashPassword(token.RefreshToken);
                user.Data.RefreshTokenExpiresAt = DateTime.UtcNow.AddDays(7);
                user.Data.RefreshTokenRevokedAt = null;

               // var updated= _services.UpdateUpdateRefreachToken(user.Data);

               
                
                    return  token;




                

                

            }

            return null;

        }
        
        public  async Task<TokenResponse> Refreash(RefreshRequest refresh)
        {
            var user =await _services.GetUserByEmail(refresh.Email);

            if (user.Data == null||user.Data.RefreshTokenExpiresAt<=DateTime.UtcNow ||refresh.RefreshToken!= user.Data.RefreshTokenHash) { return null; }

            if (user.Data!=null ) 
            {

                var tokens=_jwt.GenerateToken(user.Data.UserID, user.Data.RoleID, user.Data.UserName);

                user.Data.RefreshTokenHash = _services.HashPassword(tokens.RefreshToken);
                user.Data.RefreshTokenExpiresAt = DateTime.UtcNow.AddDays(7);
                user.Data.RefreshTokenRevokedAt = null;


                return tokens;


            }

            return null;


        }



    }
}
