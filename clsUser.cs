using DataLayer;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLayer
{
  
    public class clsUser
    {
        
        enum enMode {AddNew=1,Update=2,Delete=3}

        enMode Mode=enMode.AddNew;

        public static enum enPermissionType { Doctor = 1, Nures = 2, Secertary = 3, Patient = 4, Register = 5 }
        public int UserID { get;  set; }
        public string UserName { get;  set; }


        public string Password { get;  set; }
        private string _PasswordHashed => HashPassword(Password);
        public string Email { get;  set; }
        public short Permissions { get; set; }

        public enPermissionType PermissionType { get; set; }
        public bool IsActive { get; set; }

        public clsUser()
        {
            
        }
        public clsUser(int userID, string userName, string password, string email, short Permissions,enPermissionType type, bool isActive)
        {
            UserID = userID;
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Permissions = Permissions;
            PermissionType = type;
            IsActive = isActive;
            Mode = enMode.Update;
        }

        public clsUser(DL_userDTO dalDto)
        {
            UserID = dalDto.UserID;
            UserName = dalDto.UserName;
            Password = dalDto.Password;
            Email = dalDto.Email;
            Permissions = dalDto.Permissions;
            PermissionType =(enPermissionType)dalDto.PermissionType;
            IsActive = dalDto.IsActive;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < byteSLength; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private DL_userDTO MapToDalDto()
        {
            string hashedPassword = thiSPassword;

            return new DL_userDTO(thiSUserID, thiSUserName, thiSPassword,
                thiSEmail, thiSPermissions, thiSIsActive);
              





        }

        // دوال CRUD الأساسية (Save, AddNewUser, UpdateUser, DeleteUser)
        public bool Save()
        {
            switch (thiSMode)
            {
                case enMode.AddNew:
                    return AddNewUser();
                case enMode.Update:
                    return UpdateUser();
                case enMode.Delete:
                    return DeleteUser();
                default:
                    return false;
            }
        }

        public bool AddNewUser()
        {
            if (UserData.IsUserNameExists(thiSUserName)) return false; // مثال على Business Rule
            DL_userDTO DTO = MapToDalDto();
            thiSUserID = UserData.AddNewUser(DTO);
            if (thiSUserID > 0) { thiSMode = enMode.Update; return true; }
            return false;
        }

        public bool UpdateUser()
        {
            DL_userDTO DataLayerDTO = MapToDalDto();
            return UserData.UpdateUser(DataLayerDTO);
        }

        public bool DeleteUser()
        {
            return UserData.DeleteUser(thiSUserID);
        }

        
        public static List<clsUser> GetAllUsers()
        {
            List<DL_userDTO> dalDtos = UserData.GetAllUsers();
            List<clsUser> blDtos = new List<clsUser>();
            foreach (var dalDto in dalDtos)
            {
                blDtoSAdd(new clsUser(dalDto));
            }
            return blDtos;
        }

        public static clsUser GetUserByID(int userID)
        {
            DL_userDTO dalDto = UserData.GetUserByID(userID);
            if (dalDto == null) return null;
            return new clsUser(dalDto);
        }

        public static clsUser GetUserByUserName(string userName,string password)
        {
            DL_userDTO dalDto = UserData.GetUserByUserName(userName,password);
            if (dalDto == null) return null;
            return new clsUser(dalDto);
        }

        //public static clsUser GetUserByUserName(string userName, string password)
        //{
        //    DL_userDTO dalDto = UserData.GetUserByUserName(userName, password);
        //    if (dalDto == null) return null;
        //    return new clsUser(dalDto);
        //}

    }
}
