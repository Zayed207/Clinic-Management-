using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLayer.User;

namespace DataLayer.Entities
{
    public class UpdateUserRequestDTO
    {


        public int UserID { get; set; }

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;



        public bool IsActive { get; set; }

        public enPermissionType PermissionType { get; set; }






    }
    public class AddUserRequestDTO
    {



        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;

     

        public bool IsActive { get; set; }

        public enPermissionType PermissionType { get; set; }




    }

    public class UserResponseDTO
    {


        public int UserID { get; set; }


        public string UserName { get; set; }





        public string Email { get; set; }
        



        public bool IsActive { get; set; }

        public short RoleID { get; set; }
        public UserResponseDTO(UserEntity User)
        {
            if (User == null) throw new ArgumentNullException("User in Api_dto 22");

            this.UserID = User.UserID;
            UserName = User.UserName;
            Email = User.Email;
           RoleID=User.RoleID_FK;

            IsActive = User.IsActive;

        }
    }


    public class LoginRequestDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class ChangePasswordDTO
    {
       // public int UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}

