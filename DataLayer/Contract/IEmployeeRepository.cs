using DataLayer.Entities;

namespace DataLayer.Contract
{
    using DataLayer.Data;
    using System.Collections.Generic;

    public interface IEmployeeRepository
    {
      public Task <DataLayerOperationResult <int >>AddEmployee(EmployeeEntity entity);
      public Task <DataLayerOperationResult <bool >>UpdateEmployee(EmployeeEntity entity);
      public Task <DataLayerOperationResult <bool >>DeleteEmployee(int id);
      public Task <DataLayerOperationResult <EmployeeEntity>> GetEmployeeByUserId(int UserId);
      public Task <DataLayerOperationResult <List<EmployeeEntity>>> GetAllEmployyesInClinicByClinicName(string clinicname);
      public Task <DataLayerOperationResult<List<EmployeeEntity>>> GetAllEmployyesInClinicByClinicID(int clinicid);
    }

   
}
