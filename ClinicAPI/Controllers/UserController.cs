using BusinessLayer.BusinessLogic;
using BusinessLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using BusinessLayer.DTOsPresentation;
using Microsoft.AspNetCore.SignalR;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices _service;

        public UserController(UserServices service)
        {
            _service = service;
        }


        [HttpPost]


        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        //done
        public async Task<ActionResult<int>> AddNewUser([FromBody] UserRequestDTO user)
        {
            var result = await _service.AddNewUser(user);

            return result.Status switch
            {
                ResultStatus.Success => Ok($"successfuladded userid = {result.Data}"),
                ResultStatus.Conflict => Conflict(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }


        [HttpPost("Authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> Authenticate([FromBody] LoginRequestDTO login)
        {
            var result = await _service.Authenticate(login.UserName, login.Password);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        [HttpPut("ChangePassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordDTO dto)
        //{
        //    var result =await _service.ChangePassword(dto.UserId, dto.OldPassword, dto.NewPassword);

        //    return result.Status switch
        //    {
        //        ResultStatus.Updated => Ok(result.Message),
        //        ResultStatus.NotFound => NotFound(result.Message),
        //        ResultStatus.Conflict => Conflict(result.Message),
        //        ResultStatus.InternalError => StatusCode(500, result.Message),
        //        _ => BadRequest(result.Message)
        //    };
        //}


        //[HttpPut("ResetPassword/{userId}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult> ResetPassword(int userId)
        //{
        //    var result =await _service.ResetPassword(userId);

        //    return result.Status switch
        //    {
        //        ResultStatus.Updated => Ok(result.Message),
        //        ResultStatus.NotFound => NotFound(result.Message),
        //        ResultStatus.InternalError => StatusCode(500, result.Message),
        //        _ => BadRequest(result.Message)
        //    };
        //}

        /// <summary>
        /// Check if username exists.
        /// </summary>

        [HttpGet("exist/{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> IsUserNameExists(string username)
        {
            var result = await _service.IsUserNameExists(username);

            return result.Status switch
            {
                ResultStatus.Conflict => Conflict(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.Success => Ok(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }


        [HttpGet("by/{userid:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> GetUserById(int userid)
        {
            var result = await _service.GetUserByID(userid);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }


        [HttpGet("{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> GetUserByUserName(string username)
        {
            var result = await _service.GetUserByUserName(username);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        [HttpPut("{userid:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateUser(int userid, [FromBody] UserRequestDTO user)
        {
            var result = await _service.UpdateUser(user);

            return result.Status switch
            {
                ResultStatus.Updated => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        // 
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var result = await _service.DeleteUserByUserID(id);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }




    }
}
