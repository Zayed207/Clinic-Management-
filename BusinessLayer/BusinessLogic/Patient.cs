using BusinessLayer.DTOsPresentation;
using AutoMapper;
using BusinessLayer.BusinessLogic;
using DataLayer.Contract;
using DataLayer.Data;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Patient
    {

        public int PatientID { get; set; }

        public int PatientPersonID { get; set; }



        public string EmergencyContactName { get; set; }

        public string EmergencyContactPhone { get; set; }

        public DateOnly RegisterDatew { get; set; }

        public Person person;


        public Patient(PatientEntity patient)
        {
            PatientID = patient.PatientID;
            PatientPersonID = patient.PatientPersonID_FK;

            EmergencyContactName = patient.EmergencyContactName;
            EmergencyContactPhone = patient.EmergencyContactPhone;
            RegisterDatew = patient.RegisterDatew;



        }

        public Patient(PatientRequestDTO patient)
        {


            EmergencyContactName = patient.EmergencyContactName;
            EmergencyContactPhone = patient.EmergencyContactPhone;
            RegisterDatew = patient.RegisterDatew;


        }
        internal static List<Patient> MedicalRecordEntityListToMedicalRecord(List<PatientEntity> clinicEntities)
        {
            var clinics = new List<Patient>();

            foreach (var entity in clinicEntities)
            {
                clinics.Add(new Patient(entity));

            }
            return clinics;
        }


    }


    public class PatientServices
        {
            private readonly IMapper _mapper;
            private readonly IPatientRepository _repo;

            public PatientServices(IPatientRepository patient, IMapper mapper)
            {
                _mapper = mapper;
                _repo = patient;
            }

        public async Task<OperationResult<int>> AddNewPatient(PatientRequestDTO patient)
        {




            var newId = await _repo.AddPatient(_mapper.Map<PatientEntity>(new Patient(patient)));
            switch (newId.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<int>.Success(newId.Data, "Patient  Added successfully.");

                case DataLayerResult.Conflict:
                    return OperationResult<int>.NotFound("Patient could not be added");

                default:
                    return OperationResult<int>.InternalError($"Unexpected error: {newId.Message}");


            }



        }
            

            public async Task<OperationResult<bool>> UpdatePatient(PatientRequestDTO patient)
            {
            var updated = await _repo.UpdatePatient(_mapper.Map<PatientEntity>(new Patient(patient)));
            switch (updated.ResultType)
                {
                    case DataLayerResult.Success:
                        return OperationResult<bool>.Success(updated.Data, "Patient updated successfully.");

                    case DataLayerResult.Conflict:
                        return OperationResult<bool>.NotFound("Patient not found.");

                    default:
                        return OperationResult<bool>.InternalError($"Unexpected error: {updated.Message}");


                }
              
                 
            }

            public async Task<OperationResult<bool>> DeleteByPatientID(int patientId)
            {
                if (patientId <= 0) return OperationResult<bool>.ValidationError("this id is not valid");

                var deleted  = await _repo.DeletePatient(patientId);
            switch (deleted.ResultType)
                {
                    case DataLayerResult.Success:
                        return OperationResult<bool>.Success(deleted.Data, "Patient deleted successfully.");

                    case DataLayerResult.Conflict:
                        return OperationResult<bool>.NotFound("Patient not found..");

                    default:
                        return OperationResult<bool>.InternalError($"Unexpected error: {deleted.Message}");


                }
              
            }

            public async Task<OperationResult<PatientInfoDTO>> GetPatientByUserID(int userId)
            {
                if (userId <= 0) return OperationResult<PatientInfoDTO>.ValidationError("this id is not valid");

                        var entity = await _repo.GetPatientInfoByUserID(userId);
                        switch (entity.ResultType)
                {
                    case DataLayerResult.Success:
                        return OperationResult<PatientInfoDTO>.Success(new PatientInfoDTO(entity.Data), "Patient  founded.");

                    case DataLayerResult.Conflict:
                        return OperationResult<PatientInfoDTO>.NotFound("Patient not found.");

                    default:
                        return OperationResult<PatientInfoDTO>.InternalError($"Unexpected error: {entity.Message}");


                }
  
             
            }

            //public async Task<OperationResult<Patient>> FindByPatientID(int patientId)
            //{

            //    if (patientId <= 0) return OperationResult<Patient>.ValidationError("this id is not valid");

            //            var entity = await _repo.FindByPatientID(patientId);
            //            switch (entity.ResultType)
            //    {
            //        case DataLayerResult.Success:
            //            return OperationResult<Patient>.Success(new Patient(entity.Data), "Medical record deleted successfully.");

            //        case DataLayerResult.Conflict:
            //            return OperationResult<Patient>.NotFound("Failed to delete medical record.");

            //        default:
            //            return OperationResult<Patient>.InternalError($"Unexpected error: {entity.Message}");


            //    }
    
               
            //}

            //public async Task<OperationResult<Patient>> FindPatientByUserName(string name)
            //{

            //var entity = await _repo.FindPatientUserName(name);
            //switch (entity.ResultType)
            //{
            //    case DataLayerResult.Success:
            //        return OperationResult<Patient>.Success(new Patient(entity.Data), "Patient  founded");

            //    case DataLayerResult.Conflict:
            //        return OperationResult<Patient>.NotFound("Patient not found");

            //    default:
            //        return OperationResult<Patient>.InternalError($"Unexpected error: {entity.Message}");


            //}
            //    }
             
            }}

            //public OperationResult<List<Patient>> GetAllPatients()
            //{
            //    try
            //    {
            //        var list = _repo.GetAllPatients();
            //        if (list == null || !list.Any())
            //            return Result<List<Patient>>.NotFound("No patients found.");

            //        return Result<List<Patient>>.Success(list.Select(e => new Patient(e)).ToList());
            //    }
            //    catch (Exception ex)
            //    {
            //        return Result<List<Patient>>.InternalError(ex.Message);
            //    }
            //}
        
    

