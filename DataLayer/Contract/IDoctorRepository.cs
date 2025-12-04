using DataLayer.Entities;

namespace DataLayer.Contract
{
    using DataLayer.Data;
    using System.Collections.Generic;
    using System.Numerics;

    public interface IDoctorRepository
    {
       public  Task<DataLayerOperationResult< int >>AddDoctor(DoctorEntity doctor);
       public  Task<DataLayerOperationResult<bool >>UpdateDoctor(DoctorEntity doctor);
       public  Task<DataLayerOperationResult<bool>> DeleteDoctorByEmployeeID(int doctorid);
       public   Task<DataLayerOperationResult<DoctorEntity>> GetDoctorById(int doctorid);
       public  Task<DataLayerOperationResult<List<DoctorEntity> >>GetAllDoctors();
       public   Task<DataLayerOperationResult<bool>> IsDoctorExistByEmployeeID(int employeeid);
        
       public   Task<DataLayerOperationResult<DoctorEntity>> GetDoctorByUserId(int userId);
         
       public   Task<DataLayerOperationResult<DoctorEntity>> GetDoctorByClinicId(int clinicId);
       public  Task<DataLayerOperationResult<List<DoctorEntity>>> GetAllDoctorsInClinc(int clinicid);
       public   Task<DataLayerOperationResult<List<DoctorEntity>>> GetAllDoctorsInClinc(string clinicname);
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
