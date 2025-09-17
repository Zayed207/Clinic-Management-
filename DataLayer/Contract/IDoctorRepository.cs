using DataLayer.Entities;

namespace DataLayer.Contract
{
    using System.Collections.Generic;
    using System.Numerics;

    public interface IDoctorRepository
    {
        Task< int >AddDoctor(DoctorEntity entity);
        Task< bool >UpdateDoctor(DoctorEntity entity);
        Task<bool> DeleteDoctor(int id);
         Task<DoctorEntity?> GetDoctorById(int id);
       Task<List<DoctorEntity> >GetAllDoctors();
         Task<bool> IsDoctorExist(int employeeid);
         
         Task<DoctorEntity> GetDoctorByUserId(int employeeId);
         
         Task<DoctorEntity> GetDoctorByClinicId(int employeeId);
          Task<List<DoctorEntity>> GetAllDoctorsInClinc(int clinicid);



         Task<List<DoctorEntity>> GetAllDoctorsInClinc(string clinicname);
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
