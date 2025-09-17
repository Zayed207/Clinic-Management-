using DataLayer.Entities;

namespace DataLayer.Contract
{
    using System.Collections.Generic;

    public interface IDoctorTypeRepository
    {
        int AddDoctorType(DoctorTypeEntity entity);
        bool UpdateDoctorType(DoctorTypeEntity entity);
        bool DeleteDoctorType(int id);
        DoctorTypeEntity? GetDoctorTypeById(int id);
        int? GetPaymentProviderIDByName(string name);
        List<DoctorTypeEntity> GetAllDoctorTypes();
    }
}
