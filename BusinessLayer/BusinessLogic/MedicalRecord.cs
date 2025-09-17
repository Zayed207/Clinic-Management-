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
namespace BusinessLayer
{
    public class MedicalRecord
    {

        public int MRN_ID { get; set; }
        public int PatientID_FK { get; set; }
        public string BloodType { get; set; }
        public string ChronicDiseases { get; set; }
        public DateTime IssueDate { get; set; }

        public string Notes { get; set; }
        IMapper mapper;

        public MedicalRecord(MedicalRecordEntity MRN)
        {
            MRN_ID = MRN.MRNID;
            PatientID_FK = MRN.PatientID_FK;
            BloodType = MRN.BloodType;
            ChronicDiseases = MRN.ChronicDiseases;
            IssueDate = MRN.IssueDate;

            Notes = MRN.Notes;
        }
        public MedicalRecord(MedicalRecordRequestDTO MRN)
        {
            MRN_ID = MRN.MRN_ID;
            PatientID_FK = MRN.PatientID_FK;
            BloodType = MRN.BloodType;
            ChronicDiseases = MRN.ChronicDiseases;
            IssueDate = MRN.IssueDate;

            Notes = MRN.Notes;
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
            try
            {
                int id =await _repo.AddMedicalRecord(_mapper.Map<MedicalRecordEntity>(record));

                if (id > 0)
                    return OperationResult<int>.Success(id, "Medical record created successfully.");

                return OperationResult<int>.InternalError("Failed to create medical record.");
            }
            catch (Exception ex)
            {
                return OperationResult<int>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        // Update record
        public async Task<OperationResult<bool>> UpdateMedicalRecord(MedicalRecord record)
        {
            try
            {
                bool updated =await _repo.UpdateMedicalRecord(_mapper.Map<MedicalRecordEntity>(record));

                if (updated)
                    return OperationResult<bool>.Updated("Medical record updated successfully.");

                return OperationResult<bool>.NotFound("Medical record not found.");
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        // Delete record
        public async Task<OperationResult<bool>> DeleteMedicalRecord(int mrnId)
        {
            try
            {
                bool deleted =await _repo.DeleteMedicalRecord(mrnId);

                if (deleted)
                    return OperationResult<bool>.Success(true, "Medical record deleted successfully.");

                return OperationResult<bool>.NotFound("Medical record not found.");
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        // Get last record for patient
        public async Task<OperationResult<MedicalRecord>> GetLastMedcalRecordForPatientByUserId(int userId)
        {
            try
            {
                var entity =await _repo.GetLastMedcalRecordForPatientByuserId(userId);

                if (entity == null)
                    return OperationResult<MedicalRecord>.NotFound("No medical record found for this patient.");

                return OperationResult<MedicalRecord>.Success(new MedicalRecord(entity));
            }
            catch (Exception ex)
            {
                return OperationResult<MedicalRecord>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        // Get all records for patient
        public async Task<OperationResult<List<MedicalRecord>>> GetMedicalRecordsForPatientByUserID(int userId)
        {
            try
            {
                var entities =await _repo.GetMedicalRecordsForPatientByUserID(userId);

                if (entities == null || entities.Count == 0)
                    return OperationResult<List<MedicalRecord>>.NotFound("No medical records found for this patient.");

                var records = entities.Select(e => new MedicalRecord(e)).ToList();
                return OperationResult<List<MedicalRecord>>.Success(records);
            }
            catch (Exception ex)
            {
                return OperationResult<List<MedicalRecord>>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

    }
}

