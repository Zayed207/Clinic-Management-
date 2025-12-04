using AutoMapper;
using BusinessLayer.BusinessLogic;
using ClinicAPI.temp.DTOs___Validations;
using DataLayer.Contract;
using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace BusinessLayer
{
    public class Doctor
    {
        public int DoctorID { get; set; }

        public int EmployeeID{ get; set; }

        public string MedicalLicenseNumber { get; set; } = null!;

        public short? YearsOfExperience { get; set; }



        public bool? IsOnCall { get; set; }

        public string Specialization { get; set; } = null!;

        public short DoctorTypeID{ get; set; }

        public decimal Price { get; set; }


        public Doctor(DoctorEntity doctor)
        {
            DoctorID = doctor.DoctorID;
            EmployeeID= doctor.EmployeeID_FK;
            MedicalLicenseNumber = doctor.MedicalLicenseNumber;
            YearsOfExperience = doctor.YearsOfExperience;
           
            IsOnCall= doctor.IsOnCall;
            Specialization = doctor.Specialization;
            DoctorTypeID= doctor.DoctorTypeID_FK;
            Price = doctor.Price;

        }
        public Doctor(DoctorRequestDTO doctor)
        {
            EmployeeID= doctor.EmployeeID;
            MedicalLicenseNumber = doctor.MedicalLicenseNumber;
            YearsOfExperience = doctor.YearsOfExperience;
            
            IsOnCall = doctor.IsOnCall;
            Specialization = doctor.Specialization;
            DoctorTypeID= doctor.DoctorTypeID;
            Price = doctor.Price;


        }


        internal static List<Doctor> DoctorEntityListToDoctor(List<DoctorEntity> clinicEntities)
        {
            var clinics = new List<Doctor>();

            foreach (var entity in clinicEntities)
            {
                clinics.Add(new Doctor(entity));

            }
            return clinics;
        }
    }




    public class DoctorServices
    {
        readonly IDoctorRepository _repo;
        readonly IMapper _mapper;

        public DoctorServices(IDoctorRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<OperationResult<int>> AddNewDoctor(DoctorRequestDTO doctor)
        {
            //validation->is employee exist? ->add doctor
            var d = await _repo.IsDoctorExistByEmployeeID(doctor.EmployeeID);
            if (d.ResultType==DataLayerResult.Conflict)
            {
                return OperationResult<int>.Conflict("This Doctor is already exist");
            }

            if(d.ResultType == DataLayerResult.InternalError) 
                return OperationResult<int>.InternalError($"Unexpected error: {d.Message}");



            var result = await _repo.AddDoctor(_mapper.Map<DoctorEntity>(new Doctor(doctor)));
            switch (result.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<int>.Success(result.Data, " created successfully.");

                case DataLayerResult.Conflict:
                    return OperationResult<int>.NotFound("This Doctor is already exist");

                default:
                    return OperationResult<int>.InternalError($"Unexpected error: {result.Message}");
            }
          
           

      
        }
        public async Task<OperationResult<bool>> UpdateDoctor(DoctorRequestDTO doctor)
        {
           
            var d = await _repo.IsDoctorExistByEmployeeID(doctor.EmployeeID);
            if (d.ResultType == DataLayerResult.Conflict)
            {
                return OperationResult<bool>.Conflict("This Doctor is not exist");
            }

            if (d.ResultType == DataLayerResult.InternalError)
                return OperationResult<bool>.InternalError($"Unexpected error: {d.Message}");



            var result = await _repo.UpdateDoctor(_mapper.Map<DoctorEntity>(new Doctor(doctor)));
            switch (result.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<bool>.Success(result.Data, " created successfully.");

                case DataLayerResult.Conflict:
                    return OperationResult<bool>.NotFound("This Doctor is already exist");

                default:
                    return OperationResult<bool>.InternalError($"Unexpected error: {result.Message}");
            }
        }


    
        public async Task<OperationResult<bool>> DeleteDoctorByEmployeeID(int employeeId)
        
        {
            if (employeeId <= 0) return OperationResult<bool>.ValidationError("this id is not valid");
            var deleted =await _repo.DeleteDoctorByEmployeeID(employeeId);
            switch (deleted.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<bool>.Success(deleted.Data, "deleted successfuly");

                case DataLayerResult.Conflict:
                    return OperationResult<bool>.NotFound("Doctor not found or nothing to delete.");

                default:
                    return OperationResult<bool>.InternalError($"Unexpected error: {deleted.Message}");
            }
           
                }
               


        
        public async Task<OperationResult<Doctor>> GetDoctorById(int employeeId)
        {
            if (employeeId <= 0) return OperationResult<Doctor>.ValidationError("this id is not valid");
            var result = await _repo.GetDoctorById(employeeId);

            switch (result.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<Doctor>.Success(new Doctor(result.Data), "founded");

                case DataLayerResult.Conflict:
                    return OperationResult<Doctor>.NotFound("this id not exist in database.");

                default:
                    return OperationResult<Doctor>.InternalError($"Unexpected error: {result.Message}");
            }
            


        
        
        }
        public async Task<OperationResult<Doctor>> GetDoctorByUserId(int userId)
        {
            if (userId <= 0) return OperationResult<Doctor>.ValidationError("this id is not valid");
            var doctor=await _repo.GetDoctorById(userId);

            switch (doctor.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<Doctor>.Success(new Doctor(doctor.Data), "founded");

                case DataLayerResult.Conflict:
                    return OperationResult<Doctor>.NotFound("this id not exist in database.");

                default:
                    return OperationResult<Doctor>.InternalError($"Unexpected error: {doctor.Message}");
            }
        }
        public async Task<OperationResult<Doctor>> GetDoctorByClinicId(int clinicId) {

            if (clinicId <= 0) return OperationResult<Doctor>.ValidationError("this id is not valid");
           
            
            var doctor = await _repo.GetDoctorById(clinicId);

           
            switch (doctor.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<Doctor>.Success(new Doctor(doctor.Data), "founded");

                case DataLayerResult.Conflict:
                    return OperationResult<Doctor>.NotFound("this id not exist in database.");

                default:
                    return OperationResult<Doctor>.InternalError($"Unexpected error: {doctor.Message}");
            }

        }

        public async Task<OperationResult<List<Doctor>>> GetAllDoctorsInClinc(int clinicid)
        {

            var doctors = new List<Doctor>();

            var list = await _repo.GetAllDoctors();
            switch (list.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<List<Doctor>>.Success(Doctor.DoctorEntityListToDoctor(list.Data), "founded");

                case DataLayerResult.Conflict:
                    return OperationResult<List<Doctor>>.NotFound("this clinic dosen't has doctors");

                default:
                    return OperationResult<List<Doctor>>.InternalError($"Unexpected error: {list.Message}");
            }

        }


        public async Task<OperationResult< List<Doctor>>> GetAllDoctorsInClinc(string clinicname)
        {




            var doctors = new List<Doctor>();

            var list = await _repo.GetAllDoctors();
            switch (list.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<List<Doctor>>.Success(Doctor.DoctorEntityListToDoctor(list.Data), "founded");

                case DataLayerResult.Conflict:
                    return OperationResult<List<Doctor>>.NotFound("this clinic dosen't has doctors");

                default:
                    return OperationResult<List<Doctor>>.InternalError($"Unexpected error: {list.Message}");
            }

        }
    }
}
