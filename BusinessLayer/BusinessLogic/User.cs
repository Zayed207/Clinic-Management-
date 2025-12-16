using AutoMapper;
using BusinessLayer;
using BusinessLayer.BusinessLogic;
using BusinessLayer.DTOsPresentation;
using DataLayer;
using DataLayer.Contract;
using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.IdentityModel.Tokens;
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

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;

        public short RoleID{ get; set; }

        public bool IsActive { get; set; }

        public enPermissionType PermissionType { get; set; }
        


       
        public User(UserEntity dalDto)
        {
            UserID = dalDto.UserID;
            UserName = dalDto.UserName;
            Password = dalDto.Password;
            Email = dalDto.Email;
            RoleID = dalDto.RoleID_FK;

            IsActive = dalDto.IsActive;
        }

        public User(UserRequestDTO dalDto)
        {
            
            UserName = dalDto.UserName;
            Password = dalDto.Password;
            Email = dalDto.Email;
            RoleID = (short)dalDto.PermissionType;

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
        public async Task <OperationResult<int> >AddNewUser(UserRequestDTO newuser)
        {
            var exist= await _repo.IsUserNameExists(newuser.UserName);

            switch (exist.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<int>.Success(1, "This username already exists.");

                case DataLayerResult.Conflict:
                    return OperationResult<int>.NotFound("This username aviable.");
                default:
                    return OperationResult<int>.InternalError($"Unexpected error: {exist.Message}");
            }

          

            newuser.Password = HashPassword(newuser.Password);
            var userId = await _repo.AddUser(_mapper.Map<UserEntity>(new User(newuser)));
            switch (userId.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<int>.Success(userId.Data, "User created successfully");

                case DataLayerResult.Conflict:
                    return OperationResult<int>.NotFound("Failed to create user.");

                default:
                    return OperationResult<int>.InternalError($"Unexpected error: {userId.Message}");


            }

            

            
           
         
        }

        public async Task<OperationResult<bool>> UpdateUser(UserRequestDTO user)
        {


            user.Password = HashPassword(user.Password);
            var updated = await _repo.UpdateUser(_mapper.Map<UserEntity>(user));
           
            switch (updated.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<bool>.Success(updated.Data, "User updated successfully.");

                case DataLayerResult.Conflict:
                    return OperationResult<bool>.NotFound("User not found");

                default:
                    return OperationResult<bool>.InternalError($"Unexpected error: {updated.Message}");


            }


         
        }

        public async Task<OperationResult<bool>> DeleteUserByUserID(int userId)
        {
             if (userId <= 0) return OperationResult<bool>.ValidationError("this id is not valid");

            var deleted = await _repo.DeleteUser(userId);
            switch (deleted.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<bool>.Success(deleted.Data, "User deleted successfully.");

                case DataLayerResult.Conflict:
                    return OperationResult<bool>.NotFound("User not found.");

                default:
                    return OperationResult<bool>.InternalError($"Unexpected error: {deleted.Message}");


            }
          

          
        }

        public async Task<OperationResult<User>> GetUserByID(int userId)
        {
            if (userId <= 0) return OperationResult<User>.ValidationError("this id is not valid");

            var entity = await _repo.GetUserById(userId);
            switch (entity.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<User>.Success(new User(entity.Data), "User  founded.");

                case DataLayerResult.Conflict:
                    return OperationResult<User>.NotFound("User not found.");

                default:
                    return OperationResult<User>.InternalError($"Unexpected error: {entity.Message}");


            }
            

        }

        public async Task<OperationResult<User>> GetUserByUserName(string userName, string password)
        {
            if (userName.IsNullOrEmpty()|| password.IsNullOrEmpty()) return OperationResult<User>.ValidationError("validation erorr ");

            password = HashPassword(password);
            var entity = await _repo.GetUserByUserName(userName, password);
            switch (entity.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<User>.Success(new User(entity.Data), "User  founded.");

                case DataLayerResult.Conflict:
                    return OperationResult<User>.NotFound("User not found.");

                default:
                    return OperationResult<User>.InternalError($"Unexpected error: {entity.Message}");


            }
           

      
        }

       
        public async Task<OperationResult<User>> Authenticate(string userName, string password)
            {
                try
                {

                password= HashPassword(password);
                    var userEntity =await _repo.GetUserByUserName(userName, password);
                    if (userEntity == null)
                        return OperationResult<User>.NotFound("Invalid username or password");

                    var user = new User(userEntity.Data);
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

            // business validation
            if (userId <= 0)
                return OperationResult<bool>.ValidationError("this userId is not valid");
            if (oldPassword.IsNullOrEmpty() || newPassword.IsNullOrEmpty()) 
                return OperationResult<bool>.ValidationError("validation password erorr ");

            //logic validation
            var userEntity = await _repo.GetUserById(userId);

            if (userEntity.Data.Password!= HashPassword(oldPassword))
                return OperationResult<bool>.Conflict("Old password is incorrect");

            //update
            userEntity. Data.Password = HashPassword(newPassword);
            var updated = await _repo.UpdateUser(userEntity.Data);

            switch (updated.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<bool>.Success(updated.Data, "User updated successfully.");

              

                default:
                    return OperationResult<bool>.InternalError($"Unexpected error: {updated.Message}");


            }


           
                 
            }

            
            public async Task<OperationResult<bool>> ResetPassword(int userId)
            {
              throw new NotImplementedException();
                  
            }

            /// <summary>
            /// Check if username already exists.
            /// </summary>
            public async Task<OperationResult<bool>> IsUserNameExists(string username)
            {
            if (username.IsNullOrEmpty()) return OperationResult<bool>.ValidationError("this username is empty");

            var exist= await _repo.IsUserNameExists(username);
            switch (exist.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<bool>.Success(exist.Data, "already exists");

                case DataLayerResult.Conflict:
                    return OperationResult<bool>.NotFound("Username is available.");

                default:
                    return OperationResult<bool>.InternalError($"Unexpected error: {exist.Message}");


            }
           
               
            }


        public async Task<OperationResult<User>> GetUserByUserName(string username)
        {
            if (username.IsNullOrEmpty()) return OperationResult<User>.ValidationError("this username is empty");

            var entity = await _repo.GetUserByUserName(username);
            switch (entity.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<User>.Success(new User(entity.Data), "exist");

                case DataLayerResult.Conflict:
                    return OperationResult<User>.NotFound("Username is not exist.");

                default:
                    return OperationResult<User>.InternalError($"Unexpected error: {entity.Message}");


            }

            

           
        }

    }
    }
        

  

    

