using DataLayer.Entities;

namespace DataLayer.Contract
{
    using DataLayer.Data;
    using DataLayer.ReadModel.Doctor;
    using System.Collections.Generic;
    using System.Numerics;

    public interface IDoctorRepository
    {
       public  Task<DataLayerOperationResult< int >>AddDoctor(DoctorEntity doctor);
       public  Task<DataLayerOperationResult<bool >>UpdateDoctor(DoctorEntity doctor);
       public  Task<DataLayerOperationResult<bool>> DeleteDoctorByEmployeeID(int doctorid);
      
       public  Task<DataLayerOperationResult<List<DoctorEntity> >>GetAllDoctors();
       public   Task<DataLayerOperationResult<bool>> IsDoctorExistByEmployeeID(int employeeid);
        
       public   Task<DataLayerOperationResult<DoctorInfo>> GetDoctorInfoByUserId(int userId);
         
       public   Task<DataLayerOperationResult<DoctorEntity>> GetDoctorByClinicId(int clinicId);
        public Task<DataLayerOperationResult<DoctorEntity>> GetDoctorByEmployeeID(int employeeid);


    }

   
}
