//using APILayer.DTOs;
//using APILayer.Global;
//using BusinessLayer;

//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace APILayer.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LoginController : ControllerBase
//    {
//       public API_UserDTO CheckUserExist(string user,string password)
//        {


//           Authentication.CurrentUser = Authentication.IsUserExist(user, password);

//            return  new API_UserDTO(Authentication.CurrentUser);
        
        
//        }



//    }
//}
