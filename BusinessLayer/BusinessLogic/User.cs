using AutoMapper;
using BusinessLayer;
using BusinessLayer.BusinessLogic;
using DataLayer;
using DataLayer.Contract;
using DataLayer.Data;
using DataLayer.Entities;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class User
    {

      

        public enum enPermissionType { Doctor = 1, Nures = 2, Secertary = 3, Patient = 4, Register = 5 }
        public int UserID { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }
        public short? Permissions { get; set; }

        public enPermissionType PermissionType { get; set; }
        public bool IsActive { get; set; }


       
        public User(UserEntity dalDto)
        {
            UserID = dalDto.UserID;
            UserName = dalDto.UserName;
            Password = dalDto.Password;
            Email = dalDto.Email;
            Permissions = dalDto.Permissions;

            IsActive = dalDto.IsActive;
        }

        public User(UpdateUserRequestDTO dalDto)
        {
            UserID = dalDto.UserID;
            UserName = dalDto.UserName;
            Password = dalDto.Password;
            Email = dalDto.Email;
            Permissions = dalDto.Permissions;

            IsActive = dalDto.IsActive;
        }
        public User(AddUserRequestDTO dalDto)
        {
           
            UserName = dalDto.UserName;
            Password = dalDto.Password;
            Email = dalDto.Email;
            Permissions = dalDto.Permissions;

            
        }
    }


    public class UserServices
    {


       

        
            private readonly IUserRepository _repo;
            private readonly IMapper _mapper;

            public UserServices(IUserRepository repo, IMapper mapper)
            {
                _repo = repo;
                _mapper = mapper;
            }
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public async Task <OperationResult<int> >AddNewUser(AddUserRequestDTO newuser)
        {
         

             
            if (await _repo.IsUserNameExists(newuser.UserName))
            {
                return  OperationResult<int>.Conflict("This username already exists.");
            }

            var user = new User(newuser);
            user.Permissions = (int)User.enPermissionType.Register;
            try
            {
                user.Password = HashPassword(user.Password);
                int userId = await _repo.AddUser(_mapper.Map<UserEntity>(user));

                if (userId > 0)
                    return OperationResult<int>.Success(userId, "User created successfully.");

                return OperationResult<int>.InternalError("Failed to create user.");
            }
            catch (Exception ex)
            {
                return OperationResult<int>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        public async Task<OperationResult<bool>> UpdateUser(UpdateUserRequestDTO user)
        {
            if (await _repo.IsUserNameExists(user.UserName))
            {
                return OperationResult<bool>.Conflict("This username already exists.");
            }
            try

            {

                user.Password=HashPassword(user.Password);
                bool updated = await _repo.UpdateUser(_mapper.Map<UserEntity>(user));

                if (updated)
                    return OperationResult<bool>.Updated("User updated successfully.");
                else
                    return OperationResult<bool>.NotFound("User not found or nothing to update.");
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        public async Task<OperationResult<bool>> DeleteUserByUserID(int id)
        {
            try
            {
                bool deleted =await _repo.DeleteUser(id);

                if (deleted)
                    return OperationResult<bool>.Success(true, "User deleted successfully.");
                else
                    return OperationResult<bool>.NotFound("User not found.");
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        public async Task<OperationResult<User>> GetUserByID(int userID)
        {
            try
            {
                var entity =await _repo.GetUserByID(userID);

                if (entity == null)
                    return OperationResult<User>.NotFound("User not found.");

                return OperationResult<User>.Success(new User(entity), "User found.");
            }
            catch (Exception ex)
            {
                return OperationResult<User>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        public async Task<OperationResult<User>> GetUserByUserName(string userName, string password)
        {
            try
            {
                password = HashPassword(password);
                var entity =await _repo.GetUserByUserName(userName, password);

                if (entity == null)
                    return OperationResult<User>.NotFound("Invalid username or password.");

                return OperationResult<User>.Success(new User(entity), "Login successful.");
            }
            catch (Exception ex)
            {
                return OperationResult<User>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        /// <summary>
        /// Authenticate user by username and password.
        /// </summary>
        public async Task<OperationResult<User>> Authenticate(string userName, string password)
            {
                try
                {

                password= HashPassword(password);
                    var userEntity =await _repo.GetUserByUserName(userName, password);
                    if (userEntity == null)
                        return OperationResult<User>.NotFound("Invalid username or password");

                    var user = new User(userEntity);
                    return OperationResult<User>.Success(user, "Login successful");
                }
                catch (Exception ex)
                {
                    return OperationResult<User>.InternalError($"Unexpected error: {ex.Message}");
                }
            }

            /// <summary>
            /// Change password securely.
            /// </summary>
            public async Task<OperationResult<bool>> ChangePassword(int userId, string oldPassword, string newPassword)
            {
                try
                {

                    var userEntity = await _repo .GetUserByID(userId);
                    if (userEntity == null)
                        return OperationResult<bool>.NotFound("User not found");

                    // تحقق إن الباسورد القديم صحيح
                    if (userEntity.Password != HashPassword(oldPassword))
                        return OperationResult<bool>.Conflict("Old password is incorrect");

                    userEntity.Password = HashPassword(newPassword);
                    bool updated =await _repo.UpdateUser(userEntity);

                    return updated
                        ? OperationResult<bool>.Updated("Password updated successfully")
                        : OperationResult<bool>.InternalError("Failed to update password");
                }
                catch (Exception ex)
                {
                    return OperationResult<bool>.InternalError($"Unexpected error: {ex.Message}");
                }
            }

            /// <summary>
            /// Reset password by admin (default password = '123456' for example).
            /// </summary>
            public async Task<OperationResult<bool>> ResetPassword(int userId)
            {
                try
                {
                    var userEntity =await _repo.GetUserByID(userId);
                    if (userEntity == null)
                        return OperationResult<bool>.NotFound("User not found");

                    userEntity.Password = HashPassword("123456"); // أو ممكن تبعتها بالإيميل
                    bool updated =await _repo.UpdateUser(userEntity);

                    return updated
                        ? OperationResult<bool>.Updated("Password reset successfully")
                        : OperationResult<bool>.InternalError("Failed to reset password");
                }
                catch (Exception ex)
                {
                    return OperationResult<bool>.InternalError($"Unexpected error: {ex.Message}");
                }
            }

            /// <summary>
            /// Check if username already exists.
            /// </summary>
            public async Task<OperationResult<bool>> IsUserNameExists(string username)
            {
                try
                {
                    bool exists =await _repo.IsUserNameExists(username);
                    return exists
                        ? OperationResult<bool>.Conflict("Username already exists")
                        : OperationResult<bool>.Success(false, "Username is available");
                }
                catch (Exception ex)
                {
                    return OperationResult<bool>.InternalError($"Unexpected error: {ex.Message}");
                }
            }

            
         
        }
    }
        

  

    

