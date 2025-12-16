using DataLayer.Entities;

namespace DataLayer.Contract
{
    using DataLayer.Data;
    using DataLayer.ReadModel.MedicalRecord;
    using System.Collections.Generic;

    public interface IMedicalRecordRepository
    {
        public Task<DataLayerOperationResult<int>> AddMedicalRecord(MedicalRecordEntity record);
        public Task<DataLayerOperationResult<bool>> UpdateMedicalRecord(MedicalRecordEntity record);
        public Task<DataLayerOperationResult<bool>> DeleteMedicalRecord(int recordId);
        public Task<DataLayerOperationResult<MedicalRecordEntity>> GetMedicalRecordById(int recordId);
        public Task<DataLayerOperationResult<List<MedicalRecordEntity>>> GetAllMedicalRecordOfPatient(int patientId);
        public Task<DataLayerOperationResult<List<MedicalRecordEntity>>> GetMedicalRecordsForPatientByUserID(int userId);
        public  Task<DataLayerOperationResult<MedicalRecordInfo>> GetLastMedcalRecordForPatientByUserID(int userid);
    }
}

