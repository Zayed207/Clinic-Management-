using DataLayer.Entities;

namespace DataLayer.Contract
{
    using System.Collections.Generic;

    public interface IMedicalRecordRepository
    {
       Task <int> AddMedicalRecord(MedicalRecordEntity entity);
       Task <bool> UpdateMedicalRecord(MedicalRecordEntity entity);
       Task <bool> DeleteMedicalRecord(int id);
       Task < List<MedicalRecordEntity> >GetMedicalRecordsForPatientByUserID(int userid);
       
    Task   < MedicalRecordEntity >GetLastMedcalRecordForPatientByuserId(int mrnId);
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
