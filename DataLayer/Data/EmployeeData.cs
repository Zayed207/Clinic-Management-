using DataLayer.Contract;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public  async Task<int> AddEmployee(EmployeeEntity employee)
        {
            
                _context.Employees.Add(employee);
            await    _context.SaveChangesAsync();   

                return employee.EmployeeID;
            
            }
        public  async Task<bool> UpdateEmployee(EmployeeEntity employee)
        {
            int rowsAffected=-1;
            _context.Employees.Update(employee);


           rowsAffected =await _context.SaveChangesAsync(); 

                return rowsAffected > 0; 
            
            
        }
        public  async Task<bool> DeleteEmployee(int personId)
        {
           
                var employee =await _context.Employees.FindAsync(personId);
                if (employee == null)
                    return false;

                _context.Employees.Remove(employee);
         return await  _context.SaveChangesAsync() > 0; // بيرجع عدد الصفوف اللي اتأثرت

         
        }
        public async Task<bool> DeleteEmployeeByNationalID(string nationalid)
        {

            var employee = _context.Employees.Find(nationalid);
            if (employee == null)
                return false;

            _context.Employees.Remove(employee);
         return   await _context.SaveChangesAsync()>0; // بيرجع عدد الصفوف اللي اتأثرت



        }
        public  async Task<EmployeeEntity> GetEmployeeById(int personid)
        {
           
                EmployeeEntity employeeEntity =await _context.Employees.FirstOrDefaultAsync(x => x.PersonID_FK == personid); ;
                return employeeEntity;
            
        }
        public  async Task<List<EmployeeEntity>> GetAllEmployees()
        {
         
                List<EmployeeEntity> employeeEntity =await _context .Employees.AsNoTracking().ToListAsync();

                return employeeEntity;

            
           

        }

        public Task<EmployeeEntity> GetEmployeeByUserId(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmployeeEntity>> GetAllEmployyesInClinicByClinicName(string clinicname)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmployeeEntity>> GetAllEmployyesInClinicByClinicID(int clinicid)
        {
            throw new NotImplementedException();
        }
    }
}
