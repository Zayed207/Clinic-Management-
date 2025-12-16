using DataLayer.Entities;

namespace DataLayer.Contract
{
    using DataLayer.Data;
    using DataLayer.ReadModel.Patient;
    using System.Collections.Generic;

    public interface IPatientRepository
    {
        public Task <DataLayerOperationResult<int> >AddPatient(PatientEntity entity);
       public Task <DataLayerOperationResult<bool> >UpdatePatient(PatientEntity entity);
       public Task <DataLayerOperationResult<bool >>DeletePatient(int id);

        public Task<DataLayerOperationResult<PatientInfo>> GetPatientInfoByUserID(int userId);



    }

}
