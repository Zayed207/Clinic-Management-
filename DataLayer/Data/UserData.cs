using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.Data.SqlClient;
//using DataAccessSetting;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using DataLayer.Contract;
namespace DataLayer.Data
{


    public class UserData:IUserRepository
    {
		private readonly Clinicdbcontext _context;
		public UserData(Clinicdbcontext context)
		{
			_context = context;
		}




		public async Task <int >AddUser(UserEntity user)
        {
            
            
                 _context.Users.Add(user);
            await _context.SaveChangesAsync();
                return  user.UserID;
            
        }

        public async Task  <bool >UpdateUser(UserEntity user)
        {
            using (_context)
            {
                _context.Users.Update(user);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task <bool >DeleteUser(int userId)
        {
            using (_context)
            {
                var user = _context.Users.Find(userId);
                if (user == null) return false;
                _context.Users.Remove(user);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task <UserEntity >GetUserById(int userId)
        {
            
                return await _context.Users.FirstOrDefaultAsync(x => x.UserID == userId);
            
        }

        public async Task< List<UserEntity> >GetAllUser()
        {
            
                return await _context.Users.AsNoTracking().ToListAsync();
            
        }

        public async Task<bool> IsUserNameExists(string userName)
        {
            try
            {
                
                    return await _context.Users.AnyAsync(x => x.UserName == userName);
                
            }
            catch (Exception ex) {  throw ;}
		}


        public async Task< UserEntity >GetUserByUserName(string userName, string password)
        {
			
;
				return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName && x.Password == password);
			

		}

        public async Task< UserEntity >GetUserByID(int userID)
        {
            throw new NotImplementedException();
        }
    }
}
