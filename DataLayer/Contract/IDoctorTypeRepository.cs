using DataLayer.Entities;

namespace DataLayer.Contract
{
    using DataLayer.Data;
    using System.Collections.Generic;

    public interface IDoctorTypeRepository
    {
        public  Task<DataLayerOperationResult<int>> AddDoctorType(DoctorTypeEntity entity);
        public  Task<DataLayerOperationResult<bool>> UpdateDoctorType(DoctorTypeEntity entity);
        public  Task<DataLayerOperationResult<bool>> DeleteDoctorType(int id);
        public  Task<DataLayerOperationResult<DoctorTypeEntity>> GetDoctorTypeById(int id);
      
        public  Task<DataLayerOperationResult<List<DoctorTypeEntity>>> GetAllDoctorTypes();
    }
}
