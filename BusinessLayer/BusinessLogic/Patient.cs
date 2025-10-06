using APILayer.DTOs___Validations;
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

        public DateTime RegisterDatew { get; set; }

        public Person person;

        public Patient(int patientID, int patientPersonID, string emergencyContactName,
            string emergencyContactPhone, DateTime registerDatew)
        {
            PatientID = patientID;
            PatientPersonID = patientPersonID;

            EmergencyContactName = emergencyContactName;
            EmergencyContactPhone = emergencyContactPhone;
            RegisterDatew = registerDatew;


        }
        public Patient(PatientEntity patient)
        {
            PatientID = patient.PatientID;
            PatientPersonID = patient.PatientPersonID;

            EmergencyContactName = patient.EmergencyContactName;
            EmergencyContactPhone = patient.EmergencyContactPhone;
            RegisterDatew = patient.RegisterDatew;



        }

        public Patient(PatientRequestDTO patient)
        {

            PatientPersonID = patient.PatientPersonID;

            EmergencyContactName = patient.EmergencyContactName;
            EmergencyContactPhone = patient.EmergencyContactPhone;
            RegisterDatew = patient.RegisterDatew;


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

                
                try
                {
                    var entity = _mapper.Map<PatientEntity>(new Patient(patient));
                    var newId =await _repo.AddPatient(entity);

                    if (newId > 0)
                        return OperationResult<int>.Success(newId);

                    return OperationResult<int>.Conflict("Patient could not be added.");
                }
                catch (Exception ex)
                {
                    return OperationResult<int>.InternalError(ex.Message);
                }
            }

            public async Task<OperationResult<string>> UpdatePatient(PatientRequestDTO patient)
            {
                try
                {
                    var success =await _repo.UpdatePatient(_mapper.Map<PatientEntity>(new Patient(patient)));
                    if (success)
                        return OperationResult<string>.Updated("Patient updated successfully.");

                    return OperationResult<string>.NotFound("Patient not found.");
                }
                catch (Exception ex)
                {
                    return OperationResult<string>.InternalError(ex.Message);
                }
            }

            public async Task<OperationResult<string>> DeleteByPatientID(int patientId)
            {
                try
                {
                    var success =await _repo.DeletePatient(patientId);
                    if (success)
                        return OperationResult<string>.Success("Patient deleted successfully.");

                    return OperationResult<string>.NotFound("Patient not found.");
                }
                catch (Exception ex)
                {
                    return OperationResult<string>.InternalError(ex.Message);
                }
            }

            public async Task<OperationResult<Patient>> FindPatientByUserID(int userId)
            {
                try
                {
                    var entity =await _repo.FindPatientUserID(userId);
                    if (entity == null)
                        return OperationResult<Patient>.NotFound("Patient not found.");

                    return OperationResult<Patient>.Success(new Patient(entity));
                }
                catch (Exception ex)
                {
                    return OperationResult<Patient>.InternalError(ex.Message);
                }
            }

            public async Task<OperationResult<Patient>> FindByPatientID(int patientId)
            {
                try
                {
                    var entity =await _repo.FindByPatientID(patientId);
                    if (entity == null)
                        return OperationResult<Patient>.NotFound("Patient not found.");

                    return OperationResult<Patient>.Success(new Patient(entity));
                }
                catch (Exception ex)
                {
                    return OperationResult<Patient>.InternalError(ex.Message);
                }
            }

            public async Task<OperationResult<Patient>> FindPatientByUserName(string name)
            {
                try
                {
                    var entity =await _repo.FindPatientUserName(name);
                    if (entity == null)
                        return OperationResult<Patient>.NotFound("Patient not found.");

                    return OperationResult<Patient>.Success(new Patient(entity));
                }
                catch (Exception ex)
                {
                    return OperationResult<Patient>.InternalError(ex.Message);
                }
            }

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
        }
    }
}
