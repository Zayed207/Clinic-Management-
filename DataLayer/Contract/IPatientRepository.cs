using DataLayer.Entities;

namespace DataLayer.Contract
{
    using System.Collections.Generic;

    public interface IPatientRepository
    {
       Task <int> AddPatient(PatientEntity entity);
       Task <bool> UpdatePatient(PatientEntity entity);
       Task <bool >DeletePatient(int id);
       
       Task< PatientEntity >FindPatientUserID(int userid);
       
       Task <PatientEntity >FindByPatientID(int Patientid);
       
       Task<  PatientEntity >FindPatientUserName(string patientname);
      

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
