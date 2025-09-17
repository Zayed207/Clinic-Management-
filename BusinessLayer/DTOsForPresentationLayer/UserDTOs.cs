using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class UpdateUserRequestDTO
    {


        public int UserID { get; set; }


        public string UserName { get; set; }


        public string Password { get; set; }


        public string Email { get; set; }
        public short? Permissions { get; set; }



        public bool IsActive { get; set; }

        public UpdateUserRequestDTO(int userID, string userName, string password, string email, short? permissions, bool isActive)
        {
            UserID = userID;
            UserName = userName;
            Password = password;
            Email = email;
            Permissions = permissions;
            IsActive = isActive;
        }

        
    }
    public class AddUserRequestDTO
    {




        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
        public short? Permissions { get; set; }


        
        

      


    }

    public class UserResponseDTO
    {


        public int UserID { get; set; }


        public string UserName { get; set; }





        public string Email { get; set; }
        public short? Permissions { get; set; }



        public bool IsActive { get; set; }


        public UserResponseDTO(UserEntity User)
        {
            if (User == null) throw new ArgumentNullException("User in Api_dto 22");

            this.UserID = User.UserID;
            UserName = User.UserName;
            Email = User.Email;
            Permissions = User.Permissions;

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
        public int UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}

