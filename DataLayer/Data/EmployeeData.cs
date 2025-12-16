using DataLayer.Contract;
using DataLayer.Entities;
using DataLayer.ReadModel.Employee;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public  class EmployeeData : IEmployeeRepository 
    {

		private readonly Clinicdbcontext _context;
		public EmployeeData(Clinicdbcontext context)
		{
			_context = context;
		}
      
        public async Task<DataLayerOperationResult<int>>AddEmployee(EmployeeEntity employee)
        {
            
               

                
            try
            {





                _context.Employees.Add(employee);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<int>.SuccessOperation(employee.EmployeeID);


                return DataLayerOperationResult<int>.Fail("adding not successfuly");




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/AddEmployee ", ex);


                return DataLayerOperationResult<int>.InternalError();

            }

        }
        public  async Task<DataLayerOperationResult<bool>> UpdateEmployee(EmployeeEntity employee)
        {
           
            try

            {

                var exsit = await _context.Employees.FindAsync(employee.EmployeeID);
                if (exsit == null)
                {
                    return DataLayerOperationResult<bool>.Fail("this employee is not exist");

                }



                _context.Employees.Update(employee);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("woring!!");




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/UpdateEmployee ", ex);

                return DataLayerOperationResult<bool>.InternalError();

            }


        }
        public  async Task<DataLayerOperationResult<bool>> DeleteEmployee(int personId)
        {
           
               
               

            try

            {

                var employee = await _context.Employees.Where(x=>x.PersonID_FK==personId).SingleOrDefaultAsync();
                if (employee == null)
                {
                    return DataLayerOperationResult<bool>.Fail("this doctor is not exist");

                }



                _context.Employees.Remove(employee);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("deleting is not successfuly");




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/DeleteEmployee ", ex);

                return DataLayerOperationResult<bool>.InternalError();

            }
        }
       
        public  async Task < DataLayerOperationResult<EmployeeEntity>> GetEmployeeById(int personid)
        {
           
                
               


            try

            {

                var employeeEntity = await _context.Employees.FirstOrDefaultAsync(x => x.PersonID_FK== personid);
                if (employeeEntity != null)
                {

                    return DataLayerOperationResult<EmployeeEntity>.SuccessOperation(employeeEntity);
                }

                return DataLayerOperationResult<EmployeeEntity>.Fail("this employee is not exist");










            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/GetEmployeeById ", ex);

                return DataLayerOperationResult<EmployeeEntity>.InternalError();

            }

        }
        public  async Task<DataLayerOperationResult<List<EmployeeEntity>>> GetAllEmployees()
        {
         
              


            try

            {
                var employeeEntity = await _context.Employees.AsNoTracking().ToListAsync();
                if (employeeEntity == null || employeeEntity.Count == 0) return DataLayerOperationResult<List<EmployeeEntity>>.Fail("No employees avaliable");



                return DataLayerOperationResult<List<EmployeeEntity>>.SuccessOperation(employeeEntity);

            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/GetAllEmployees ", ex);

                return DataLayerOperationResult<List<EmployeeEntity>>.InternalError();

            }

        }

       

       

        public async Task<DataLayerOperationResult<List<EmployeeEntity>>> GetAllEmployyesInClinicByClinicID(int clinicid)
        {
            try

            {
                var employeeEntity = await _context.Employees.Where(x=>x.ClinicID_FK==clinicid).AsNoTracking().ToListAsync();
                if (employeeEntity == null || employeeEntity.Count == 0) return DataLayerOperationResult<List<EmployeeEntity>>.Fail("No employees in this clinic avaliable");



                return DataLayerOperationResult<List<EmployeeEntity>>.SuccessOperation(employeeEntity);

            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/GetAllEmployyesInClinicByClinicID ", ex);

                return DataLayerOperationResult<List<EmployeeEntity>>.InternalError();

            }
        }

        Task<DataLayerOperationResult<List<EmployeeEntity>>> IEmployeeRepository.GetAllEmployyesInClinicByClinicName(string clinicname)
        {
            throw new NotImplementedException();
        }
        public async Task<DataLayerOperationResult<EmployeeInfo>> GetEmployeeInfoByUserID(int userId)
        {
            try
            {
                var data = await _context.EmployeeInfo
                    .FromSqlRaw(
                        "EXEC sp_GetEmployeeInfoByUserId @UserID",
                        new SqlParameter("@UserID", userId))
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                if (data == null)
                    return DataLayerOperationResult<EmployeeInfo>
                        .NotFound("Employee not found");

                return DataLayerOperationResult<EmployeeInfo>
                    .SuccessOperation(data);
            }
            catch (Exception ex)
            {
                Log.Error(ex,
                    "DB Error in GetEmployeeInfoByUserId | UserID: {UserID}",
                    userId);

                return DataLayerOperationResult<EmployeeInfo>
                    .InternalError();
            }
        }

    }
}
