using BusinessLayer.BusinessLogic;
using BusinessLayer;
using BusinessLayer.DTOsPresentation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Authentication;
using BusinessLayer.DTOsPresentation.AuthDTOs;
using BusinessLayer.BusinessLogic.Auth;
using Serilog;
using Microsoft.AspNetCore.Authorization;

namespace ClinicAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly UserServices _services;
        readonly JWTAuthentication _jWT;
        private readonly Login _login;

        public AuthController(UserServices services,JWTAuthentication wT, Login login)
        {
            _services = services;
            _jWT = wT;
            _login = login;
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TokenResponse>> Login([FromBody] LoginRequestDTO login)
        {
            var token =await _login.LogIn(login.UserName,login.Password);

            if (token != null) { return Ok(token); }
            else { return Unauthorized(); }


        }
        [HttpPost("Refreash")]

        public async Task<ActionResult<TokenResponse>> Refreash([FromBody] RefreshRequest request)
        {
            var token = await _login.Refreash(request);

            if (token != null)
            { return Ok(token); }
            else
            { return Unauthorized(); }


        }



    }
}
