using DataLayer.Entities;

namespace DataLayer.Contract
{
    using DataLayer.Data;
    using System.Collections.Generic;

    
        public interface IUserRepository
        {
          public  Task<DataLayerOperationResult<int>> AddUser(UserEntity user);
          public  Task<DataLayerOperationResult<bool>> UpdateUser(UserEntity user);
          public  Task<DataLayerOperationResult<bool>> DeleteUser(int userId);
          public  Task<DataLayerOperationResult<UserEntity>> GetUserById(int userId);
          public  Task<DataLayerOperationResult<List<UserEntity>>> GetAllUsers();
          public  Task<DataLayerOperationResult<bool>> IsUserNameExists(string userName);
          public Task<DataLayerOperationResult<bool>> IsEmailExists(string email);
          public  Task<DataLayerOperationResult<UserEntity>> GetUserByUserName(string userName, string password);
          public  Task<DataLayerOperationResult<UserEntity>> GetUserByUserName(string userName);
          public Task<DataLayerOperationResult<UserEntity>> GetUserByEmail(string email);


        }


    
}
