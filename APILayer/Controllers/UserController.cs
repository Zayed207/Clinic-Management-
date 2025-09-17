//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using BusinessLayer;
//using APILayer.DTOs;
//using APILayer.Global;
//namespace APILayer.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]

    
//    public class UserController : ControllerBase
//    {

//        [HttpGet]
//        [ProducesResponseType(StatusCodes.Status204NoContent)]
//       // [ProducesResponseType(StatusCodeAuthentication.Status401Unauthorized)]
//        public ActionResult<IEnumerable<List<API_UserDTO>>> GetAllUsers()
//        {
//            if (Authentication.CurrentUser.PermissionType ==clsUser.enPermissionType.Register|| 
//                Authentication.CurrentUser.PermissionType == clsUser.enPermissionType.Nures||
//                Authentication.CurrentUser.PermissionType == clsUser.enPermissionType.Patient)
//            {
//                return Unauthorized("this user not allowed to do this get all users");
//            }

            
//            return Ok();




//        }

//    }
//}
