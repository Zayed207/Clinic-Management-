using AutoMapper;
using BusinessLayer.BusinessLogic;
using BusinessLayer.DTOsForPresentationLayer;
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
    public class Clinic
    {
        public int ClinicID { get; set; }
        public string ClinicName { get; set; }
        public string LocationDescription { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string City { get; set; }

        
        public Clinic(ClinicEntity clinic)
        {
            ClinicID = clinic.ClinicID;
            ClinicName = clinic.ClinicName;
            LocationDescription = clinic.LocationDescription;

            City = clinic.City;

        }

        public Clinic(ClinicRequestDTO clinic)
        {
            ClinicID = clinic.ClinicID;
            ClinicName = clinic.ClinicName;
            LocationDescription = clinic.LocationDescription;
            Start = clinic.Start;
            End = clinic.End;
            City = clinic.City;
        }
     
    }

    public class ClinicServices
    {

        private readonly IMapper _mapper;


        readonly IClinicRepository  _repo;
        public ClinicServices(IClinicRepository clinicRepository,IMapper mapper)
        {
            _mapper = mapper;
            _repo = clinicRepository;

        }

        public async Task<OperationResult<int>> AddNewClinic(ClinicRequestDTO clinicDto)
        {
            try
            {
                var entity = _mapper.Map<ClinicEntity>(clinicDto);
                // if you want to ensure id initial value like original code:
                // entity.ClinicID = -1;
                int id =await _repo.AddClinic(entity);
                if (id > 0)
                    return OperationResult<int>.Success(id, "Clinic created successfully.");
                return OperationResult<int>.InternalError("Failed to create clinic.");
            }
            catch (Exception ex)
            {
                return OperationResult<int>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        public async Task<OperationResult<bool>> UpdateClinic(ClinicRequestDTO clinicDto)
        {
            try
            {
                var entity = _mapper.Map<ClinicEntity>(clinicDto);
                bool updated =await _repo.UpdateClinic(entity);
                if (updated)
                    return OperationResult<bool>.Updated("Clinic updated successfully.");
                return OperationResult<bool>.NotFound("Clinic not found or nothing to update.");
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        public async Task<OperationResult<bool>> DeleteClinic(int clinicId)
        {
            try
            {
                bool deleted =await _repo.DeleteClinic(clinicId);
                if (deleted)
                    return OperationResult<bool>.Success(true, "Clinic deleted successfully.");
                return OperationResult<bool>.NotFound("Clinic not found or nothing to delete.");
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        public async Task<OperationResult<Clinic>> GetClinicById(int clinicId)
        {
            try
            {
                var entity =await _repo.GetClinicById(clinicId);
                if (entity == null)
                    return OperationResult<Clinic>.NotFound("Clinic not found.");

                var model = new Clinic(entity);
                return OperationResult<Clinic>.Success(model);
            }
            catch (Exception ex)
            {
                return OperationResult<Clinic>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        public async Task<OperationResult<List<Clinic>>> GetAllClinics()
        {
            try
            {
                var entities =await _repo.GetAllClinics();
                if (entities == null || entities.Count == 0)
                    return OperationResult<List<Clinic>>.NotFound("No clinics found.");

                var mapped = entities.Select(e => new Clinic(e)).ToList();
                return OperationResult<List<Clinic>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return OperationResult<List<Clinic>>.InternalError($"Unexpected error: {ex.Message}");
            }
        }
    }
} 

