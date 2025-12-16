using DataLayer.Entities;

namespace DataLayer.Contract
{
    using DataLayer.Data;
    using DataLayer.ReadModel.Employee;
    using System.Collections.Generic;

    public interface IEmployeeRepository
    {
      public Task <DataLayerOperationResult <int >>AddEmployee(EmployeeEntity entity);
      public Task <DataLayerOperationResult <bool >>UpdateEmployee(EmployeeEntity entity);
      public Task <DataLayerOperationResult <bool >>DeleteEmployee(int id);
     
      public Task <DataLayerOperationResult <List<EmployeeEntity>>> GetAllEmployyesInClinicByClinicName(string clinicname);
      public Task <DataLayerOperationResult<List<EmployeeEntity>>> GetAllEmployyesInClinicByClinicID(int clinicid);
        public Task<DataLayerOperationResult<EmployeeInfo>> GetEmployeeInfoByUserID(int userId);
    }

   
}
