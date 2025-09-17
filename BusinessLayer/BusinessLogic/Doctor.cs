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


namespace BusinessLayer
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public int EmployeeID_FK { get; set; }
        public string MedicalLicenseNumber { get; set; }
        public int? Years_of_Experience { get; set; }
        protected int ClinicID_FK { get; set; }
        public bool? Is_On_Call { get; set; }
        public string Specialization { get; set; }
        protected int DoctorTypeID_FK { get; set; }
        public decimal Price { get; set; }

        public Doctor(DoctorEntity doctor)
        {
            DoctorID = doctor.DoctorID;
            EmployeeID_FK = doctor.Employee_ID_FK;
            MedicalLicenseNumber = doctor.MedicalLicenseNumber;
            Years_of_Experience = doctor.Years_of_Experience;
            ClinicID_FK = doctor.ClinicID_FK;
            Is_On_Call = doctor.Is_On_Call;
            Specialization = doctor.Specialization;
            DoctorTypeID_FK = doctor.DoctorTypeID_FK;
            Price = doctor.Price;

        }
        public Doctor(DoctorRequestDTO doctor)
        {
            EmployeeID_FK = doctor.Employee_ID_FK;
            MedicalLicenseNumber = doctor.MedicalLicenseNumber;
            Years_of_Experience = doctor.Years_of_Experience;
            ClinicID_FK = doctor.ClinicID_FK;
            Is_On_Call = doctor.Is_On_Call;
            Specialization = doctor.Specialization;
            DoctorTypeID_FK = doctor.DoctorTypeID_FK;
            Price = doctor.Price;

        } }

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
            if (await _repo.IsDoctorExist(doctor.Employee_ID_FK))
            {
                return OperationResult<int>.Conflict("This Doctor is already exist");
            }

            try
            {
                int id =await _repo.AddDoctor(_mapper.Map<DoctorEntity>(doctor));
                return OperationResult<int>.Success(id, "Created Successfully");
            }

            catch (Exception ex)
            {
                return OperationResult<int>.InternalError($"  unexpected erorr {ex.ToString()}");
            }
        }
        public async Task<OperationResult<bool>> UpdateDoctor(DoctorRequestDTO doctor)
        {
            bool updated =await _repo.UpdateDoctor(_mapper.Map<DoctorEntity>(doctor));
            try
            {
                if (updated)
                {
                    return OperationResult<bool>.Updated( "Updated Successfully");
                }
                else
                {
                    return OperationResult<bool>.NotFound("Doctor not found or nothing to update.");
                }
            }

            catch (Exception ex)
            {

                return OperationResult<bool>.InternalError($"Unexpected error: {ex.Message}");
            }
        }


    
        public async Task<OperationResult<bool>> DeleteDoctor(int employeeId)
        
        {
            bool deleted =await _repo.DeleteDoctor(employeeId);
            try
            {
                if (deleted)
                {
                    return OperationResult<bool>.Success(true,"deleted successfuly");
                }
                else
                {
                    return OperationResult<bool>.NotFound("Doctor not found or nothing to delete.");
                }
            }

            catch (Exception ex)
            {

                return OperationResult<bool>.InternalError($"Unexpected error: {ex.Message}");
            }


        }
        public async Task<OperationResult<Doctor>> GetDoctorById(int employeeId)
        {
            var doctor = new Doctor(await _repo.GetDoctorById(employeeId));
            if (doctor != null) return OperationResult<Doctor>.Success(doctor, "founded");

            else return OperationResult<Doctor>.NotFound("this id not exist in database");


        
        
        }
        public async Task<OperationResult<Doctor>> GetDoctorByUserId(int userId)
        {
            var doctor=new Doctor(await _repo.GetDoctorById(userId));

            if (doctor != null) return OperationResult<Doctor>.Success(doctor, "founded");

            else return OperationResult<Doctor>.NotFound("this id not exist in database");
        }
        public async Task<OperationResult<Doctor>> GetDoctorByClinicId(int clinicId) {


            var doctor = new Doctor(await _repo.GetDoctorById(clinicId));

            if (doctor != null) return OperationResult<Doctor>.Success(doctor, "founded");

            else return OperationResult<Doctor>.NotFound("this id not exist in database");


        }
        public  async Task<OperationResult< List<Doctor>>> GetAllDoctorsInClinc(int clinicid) {
            List<Doctor> doctors = new List<Doctor>();
            try
            {
                var list =await _repo.GetAllDoctors();




                if   (list == null || list.Count == 0) return OperationResult<List<Doctor>>.NotFound("this clinic dosen't has doctors");



                foreach (var d in list) { doctors.Add(new Doctor(d)); }



                return OperationResult<List<Doctor>>.Success(doctors);
            }





            catch(Exception ex) { return OperationResult<List<Doctor>>.InternalError($"  unexpected erorr {ex.ToString()}"); }
           


                
                }

        public async Task<OperationResult< List<Doctor>>> GetAllDoctorsInClinc(string clinicname)
        {

            


            List<Doctor> doctors = new List<Doctor>();
            try
            {
                var list =await _repo.GetAllDoctorsInClinc(clinicname);




                if (list == null || list.Count == 0) return OperationResult<List<Doctor>>.NotFound("this clinic dosen't has doctors");



                foreach (var d in list) { doctors.Add(new Doctor(d)); }



                return OperationResult<List<Doctor>>.Success(doctors);
            }





            catch (Exception ex) { return OperationResult<List<Doctor>>.InternalError($"  unexpected erorr {ex.ToString()}"); }


           

        }
    }
}
