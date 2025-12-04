using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APILayer.DTOs___Validations;
using AutoMapper;
using BusinessLayer.BusinessLogic;
using DataLayer.Contract;
using DataLayer.Data;
using DataLayer.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace BusinessLayer
{
    public class MedicalRecord
    {

        public int MRID { get; set; }

        public int PatientID_FK { get; set; }

        public string BloodType { get; set; } = null!;

        public string ChronicDiseases { get; set; } = null!;

        public DateOnly IssueDate { get; set; }

        public string Notes { get; set; } = null!;


        
        IMapper mapper;

        public MedicalRecord(MedicalRecordEntity MRN)
        {
            MRID = MRN.MRID;
            PatientID_FK = MRN.PatientID_FK;
            BloodType = MRN.BloodType;
            ChronicDiseases = MRN.ChronicDiseases;
            IssueDate = MRN.IssueDate;

            Notes = MRN.Notes;
        }
        public MedicalRecord(MedicalRecordRequestDTO MRN)
        {
            MRID = MRN.MRN_ID;
            PatientID_FK = MRN.PatientID_FK;
            BloodType = MRN.BloodType;
            ChronicDiseases = MRN.ChronicDiseases;
            IssueDate = MRN.IssueDate;

            Notes = MRN.Notes;
        }
        internal static List<MedicalRecord> MedicalRecordEntityListToMedicalRecord(List<MedicalRecordEntity> clinicEntities)
        {
            var clinics = new List<MedicalRecord>();

            foreach (var entity in clinicEntities)
            {
                clinics.Add(new MedicalRecord(entity));

            }
            return clinics;
        }
    }

    public class MedicalRecordServices
    {




        private readonly IMapper _mapper;
        private readonly IMedicalRecordRepository _repo;

        public MedicalRecordServices(IMedicalRecordRepository medicalRecordRepository, IMapper mapper)
        {
            _mapper = mapper;
            _repo = medicalRecordRepository;
        }

        // Add new medical record
        public async Task<OperationResult<int>> AddNewMedicalRecord(MedicalRecord record)
        {

            var id = await _repo.AddMedicalRecord(_mapper.Map<MedicalRecordEntity>(record));
            switch (id.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<int>.Success(id.Data, "Medical record created successfully.");

                case DataLayerResult.Conflict:
                    return OperationResult<int>.NotFound("Failed to create medical record.");

                default:
                    return OperationResult<int>.InternalError($"Unexpected error: {id.Message}");


            }
        }

        // Update record
        public async Task<OperationResult<bool>> UpdateMedicalRecord(MedicalRecord record)
        {

            var updated = await _repo.UpdateMedicalRecord(_mapper.Map<MedicalRecordEntity>(record));
            switch (updated.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<bool>.Success(updated.Data, "Medical record updated successfully.");

                case DataLayerResult.Conflict:
                    return OperationResult<bool>.NotFound("Failed to update medical record.");

                default:
                    return OperationResult<bool>.InternalError($"Unexpected error: {updated.Message}");


            }
            

            
        }

        // Delete record
        public async Task<OperationResult<bool>> DeleteMedicalRecord(int mrnId)
        {
            if (mrnId <= 0) return OperationResult<bool>.ValidationError("this id is not valid");

            var deleted = await _repo.DeleteMedicalRecord(mrnId);
            switch (deleted.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<bool>.Success(deleted.Data, "Medical record deleted successfully.");

                case DataLayerResult.Conflict:
                    return OperationResult<bool>.NotFound("Failed to delete medical record.");

                default:
                    return OperationResult<bool>.InternalError($"Unexpected error: {deleted.Message}");


            }
            

           
        }

        // Get last record for patient
        public async Task<OperationResult<MedicalRecord>> GetLastMedcalRecordForPatientByUserId(int userId)
        {
            if (userId <= 0) return OperationResult<MedicalRecord>.ValidationError("this id is not valid");
            var entity = await _repo.GetLastMedcalRecordForPatientByUserId(userId);
            switch (entity.ResultType)
    {
        case DataLayerResult.Success:
            return OperationResult<MedicalRecord>.Success(new MedicalRecord(entity.Data));

        case DataLayerResult.Conflict:
            return OperationResult<MedicalRecord>.NotFound("No medical record found for this patient..");

        default:
            return OperationResult<MedicalRecord>.InternalError($"Unexpected error: {entity.Message}");


    }
 


        }

        // Get all records for patient
        public async Task<OperationResult<List<MedicalRecord>>> GetMedicalRecordsForPatientByUserID(int userId)
        {

            if(userId <= 0) return OperationResult<List<MedicalRecord>>.ValidationError("this id is not valid");
            var entities = await _repo.GetMedicalRecordsForPatientByUserID(userId);
            switch (entities.ResultType)
    {
        case DataLayerResult.Success:
            return OperationResult<List<MedicalRecord>>.Success(MedicalRecord.MedicalRecordEntityListToMedicalRecord(entities.Data), "Medical record loaded successfully.");

        case DataLayerResult.Conflict:
            return OperationResult<List<MedicalRecord>>.NotFound("No medical records found for this patient.");

        default:
            return OperationResult<List<MedicalRecord>>.InternalError($"Unexpected error: {entities.Message}");


    }
   

       
        }

    }
}

