using DataLayer.Entities;

namespace DataLayer.Contract
{
    using System.Collections.Generic;

    public interface IUserRepository
    {
        Task<int >AddUser(UserEntity entity);
        Task<bool> UpdateUser(UserEntity entity);
        Task<bool >DeleteUser(int id);
        Task<UserEntity> GetUserByUserName(string userName, string password);
        Task <UserEntity >GetUserByID(int userID);
        Task< bool >IsUserNameExists(string userName);
       
    }
}
