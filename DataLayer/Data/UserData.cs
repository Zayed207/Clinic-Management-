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




		public async Task <DataLayerOperationResult<int >>AddUser(UserEntity user)
        {

            try
            {





                _context.Users.Add(user);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<int>.SuccessOperation(user.UserID);


                return DataLayerOperationResult<int>.Fail("adding not successfuly");




            }

            catch (Exception ex)
            {

                return DataLayerOperationResult<int>.InternalError();

            }
        }

        public async Task<DataLayerOperationResult<bool>> UpdateUser(UserEntity user)
        {
           
            try

            {

                var exsit = await _context.Employees.FindAsync(user.UserID);
                if (exsit == null)
                {
                    return DataLayerOperationResult<bool>.Fail("this employee is not exist");

                }



                _context.Users.Update(user);

                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("woring!!");




            }

            catch (Exception ex)
            {

                return DataLayerOperationResult<bool>.InternalError();

            }
        }

        public async Task<DataLayerOperationResult<bool>> DeleteUser(int userId)
        {
           
            try

            {
                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                {
                    return DataLayerOperationResult<bool>.Fail("this doctor is not exist");

                }



                _context.Users.Remove(user);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("deleting is not successfuly");




            }

            catch (Exception ex)
            {

                return DataLayerOperationResult<bool>.InternalError();

            }
        }

        public async Task<DataLayerOperationResult<UserEntity>> GetUserById(int userId)
        {
            
                
            try

            {

                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserID == userId);
                if (user != null)
                {

                    return DataLayerOperationResult<UserEntity>.SuccessOperation(user);
                }

                return DataLayerOperationResult<UserEntity>.Fail("this employee is not exist");










            }

            catch (Exception ex)
            {

                return DataLayerOperationResult<UserEntity>.InternalError();

            }
        }

        public async Task<DataLayerOperationResult< List<UserEntity>> >GetAllUser()
        {
            
                
            try

            {
                var Users = await _context.Users.AsNoTracking().ToListAsync();
                if (Users == null || Users.Count == 0) return DataLayerOperationResult<List<UserEntity>>.Fail("No employees avaliable");



                return DataLayerOperationResult<List<UserEntity>>.SuccessOperation(Users);

            }

            catch (Exception ex)
            {

                return DataLayerOperationResult<List<UserEntity>>.InternalError();

            }
        }

        public async Task<DataLayerOperationResult<bool>> IsEmailExists(string email)
        {
            

                try

                {

                    var employee = await _context.Users.AnyAsync(x => x.Email== email);
                    if (!employee )
                    {
                        return DataLayerOperationResult<bool>.Fail("this email is not exist");

                    }




                        return DataLayerOperationResult<bool>.SuccessOperation(true);






                }

                catch (Exception ex)
                {

                    return DataLayerOperationResult<bool>.InternalError();

                }
            }
        public async Task<DataLayerOperationResult<bool>> IsUserNameExists(string username)
        {


            try

            {

                var employee = await _context.Users.AnyAsync(x => x.UserName == username);
                if (!employee)
                {
                    return DataLayerOperationResult<bool>.Fail("this username is not exist");

                }




                return DataLayerOperationResult<bool>.SuccessOperation(true);






            }

            catch (Exception ex)
            {

                return DataLayerOperationResult<bool>.InternalError();

            }
        }


        public async Task<DataLayerOperationResult<UserEntity>> GetUserByUserName(string userName, string password)
        {
			
;
            try

            {

                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName && x.Password == password);
                if (user == null)
                {
                    return DataLayerOperationResult<UserEntity>.Fail("this doctor is not exist");

                }



                

                    return DataLayerOperationResult<UserEntity>.SuccessOperation(user);






            }

            catch (Exception ex)
            {

                return DataLayerOperationResult<UserEntity>.InternalError();

            }


        }
        public async Task<DataLayerOperationResult<UserEntity>> GetUserByUserName(string userName)
        {

            
            
            try

            {

                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
                if (user == null)
                {
                    return DataLayerOperationResult<UserEntity>.Fail("this doctor is not exist");

                }



               
                    return DataLayerOperationResult<UserEntity>.SuccessOperation(user);






            }

            catch (Exception ex)
            {

                return DataLayerOperationResult<UserEntity>.InternalError();

            }

        }

        public async Task<DataLayerOperationResult<UserEntity>> GetUserByEmail(string email)
        {



            try

            {

                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email== email);
                if (user == null)
                {
                    return DataLayerOperationResult<UserEntity>.Fail("this email is not exist");

                }




                return DataLayerOperationResult<UserEntity>.SuccessOperation(user);






            }

            catch (Exception ex)
            {

                return DataLayerOperationResult<UserEntity>.InternalError();

            }

        }

        public async Task<DataLayerOperationResult<UserEntity>> GetUserByID(int userID)
        {
            
            try

            {

                var user = await _context.Users.FindAsync(userID);
                if (user == null)
                {
                    return DataLayerOperationResult<UserEntity>.Fail("this doctor is not exist");

                }



              
                    return DataLayerOperationResult<UserEntity>.SuccessOperation(user);




            }

            catch (Exception ex)
            {

                return DataLayerOperationResult<UserEntity>.InternalError();

            }
        }

        public Task<DataLayerOperationResult<List<UserEntity>>> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
