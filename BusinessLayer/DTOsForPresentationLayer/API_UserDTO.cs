//using System.ComponentModel.DataAnnotations;
//using BusinessLayer;
//using APILayer.Global;
//namespace APILayer.DTOs
//{
//    public class API_UserDTO
//    {
//        public int UserID { get; set; }

//        public string UserName { get; set; }

//        public string Email { get; set; }
//        public short Permissions { get; set; }

//        public clsUser.enPermissionType PermissionType { get; set; }

//        public bool IsActive { get; set; }


//        public API_UserDTO(clsUser User)
//        {
//            if (User == null) throw new ArgumentNullException("User in Api_dto 22");

//            this.UserID = User.UserID;
//            UserName = User.UserName;
//            Email = User.Email;
//            Permissions = User.Permissions;
//            PermissionType = User.PermissionType;
//            IsActive = User.IsActive;

//        }
//    }
//}
