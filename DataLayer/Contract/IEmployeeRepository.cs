using DataLayer.Entities;

namespace DataLayer.Contract
{
    using System.Collections.Generic;

    public interface IEmployeeRepository
    {
       Task <int >AddEmployee(EmployeeEntity entity);
       Task <bool >UpdateEmployee(EmployeeEntity entity);
       Task <bool >DeleteEmployee(int id);
       Task <EmployeeEntity> GetEmployeeByUserId(int UserId);
       Task <List<EmployeeEntity>> GetAllEmployyesInClinicByClinicName(string clinicname);
       Task <List<EmployeeEntity>> GetAllEmployyesInClinicByClinicID(int clinicid);
    }

    //public interface IPayPalRepository
    //{
    //    int AddPayPal(PayPalEntity entity);
    //    bool UpdatePayPal(PayPalEntity entity);
    //    bool DeletePayPal(int id);
    //    PayPalEntity? GetPayPalById(int id);
    //    List<PayPalEntity> GetAllPayPals();
    //}
}
