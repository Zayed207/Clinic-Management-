using DataLayer.Entities;

namespace DataLayer.Contract
{
    using System.Collections.Generic;

    public interface IEmployeeTypeRepository
    {
        int AddEmployeeType(EmployeeTypeEntity entity);
        bool UpdateEmployeeType(EmployeeTypeEntity entity);
        bool DeleteEmployeeType(int id);
      
    }
}
