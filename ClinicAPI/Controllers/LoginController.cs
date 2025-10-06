using BusinessLayer.BusinessLogic;
using BusinessLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly UserServices _services;
        readonly JWTAuthentication _jWT;
        public LoginController(UserServices services,JWTAuthentication wT)
        {
            _services = services;
            _jWT = wT;
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> Login([FromBody] LoginRequestDTO login)
        {
            var result = await _services.GetUserByUserName(login.UserName, login.Password);

           
            if (result == null) { return NotFound(); }

            else
            {
                var token = _jWT.GenerateToken(Convert.ToString(result.Data.UserID), Convert.ToString(result.Data.Permissions), login.UserName);
                return Ok(token);
            
            }


        }

    }
}
