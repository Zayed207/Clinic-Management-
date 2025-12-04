using DataLayer.Entities;

namespace DataLayer.Contract
{
    using DataLayer.Data;
    using System.Collections.Generic;

    public interface IPatientRepository
    {
        public Task <DataLayerOperationResult<int> >AddPatient(PatientEntity entity);
       public Task <DataLayerOperationResult<bool> >UpdatePatient(PatientEntity entity);
       public Task <DataLayerOperationResult<bool >>DeletePatient(int id);

        public Task<DataLayerOperationResult<PatientEntity>>FindPatientUserID(int userid);

        public Task<DataLayerOperationResult<PatientEntity>>FindByPatientID(int Patientid);

        public Task< DataLayerOperationResult< PatientEntity >>FindPatientUserName(string patientname);
      

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
