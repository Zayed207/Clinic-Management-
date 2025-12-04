using AutoMapper;
using BusinessLayer.BusinessLogic;
using BusinessLayer.DTOsForPresentationLayer;
using BusinessLayer.Validations;
using DataLayer.Contract;
using DataLayer.Data;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BusinessLayer
{
    public class Clinic
    {
        public int ClinicID { get; set; }

        public string ClinicName { get; set; } = null!;

        public string LocationDescription { get; set; } = null!;

        public TimeOnly Start { get; set; }

        public TimeOnly End { get; set; }

        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;

        public bool Available { get; set; }

        public string? Notes { get; set; }
        public  List<string> doctorsnames { get; set; }
        public Clinic(ClinicEntity clinic)
        {
            ClinicID = clinic.ClinicID;
            ClinicName = clinic.ClinicName;
            LocationDescription = clinic.LocationDescription;
            Start= clinic.Start;
            End= clinic.End;
            Country = clinic.Country;
            City= clinic.City;
            Available = clinic.Available;
            Notes = clinic.Notes;
            

        }

        public Clinic(ClinicRequestDTO clinic)
        {
            ClinicID = clinic.ClinicID;
            ClinicName = clinic.ClinicName;
            LocationDescription = clinic.LocationDescription;
            Start = clinic.Start;
            End = clinic.End;
            Country = clinic.Country;
            City = clinic.City;
            Available = clinic.Available;
            Notes = clinic.Notes;
        }
     
        internal  static List<Clinic> ClinicEntityListToClinic(List<ClinicEntity> clinicEntities)
        {
            var clinics= new List<Clinic>();

            foreach (var entity in clinicEntities)
            {
                clinics.Add(new Clinic(entity));
                
            }
            return clinics;
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
            var check = Clinic_V.ClinicObjectCheck(clinicDto);
            if (check.Status == ResultStatus.ValidationError)return OperationResult<int>.ValidationError($"{check.Message}");

        


                var entity = _mapper.Map<ClinicEntity>(new Clinic(clinicDto));
                // if you want to ensure id initial value like original code:
                // entity.ClinicID = -1;
                var id =await _repo.AddClinic(entity);

            switch (id.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<int>.Success(id.Data, "Clinic created successfully.");

                case DataLayerResult.Conflict:
                    return OperationResult<int>.NotFound("Failed to create clinic.");

                default:
                    return OperationResult<int>.InternalError($"Unexpected error: {id.Message}");
            }


       
            
        }

        public async Task<OperationResult<bool>> UpdateClinic(ClinicRequestDTO clinicDto)
        {
            var check = Clinic_V.ClinicObjectCheck(clinicDto);
            if (check.Status == ResultStatus.ValidationError)return OperationResult<bool>.ValidationError($"{check.Message}");


            var entity = _mapper.Map<ClinicEntity>(new Clinic(clinicDto));
            var updated = await _repo.UpdateClinic(entity);

            switch (updated.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<bool>.Success(updated.Data, "Clinic updated successfully.");

                case DataLayerResult.Conflict:
                    return OperationResult<bool>.NotFound("Clinic not found or nothing to update.");

                default:
                    return OperationResult<bool>.InternalError($"Unexpected error: {updated.Message}");
            }
          
        }

        public async Task<OperationResult<bool>> DeleteClinic(int clinicId)
        {
            if (clinicId <= 0) return OperationResult<bool>.ValidationError("Clinicid notvalid.");
            var deleted = await _repo.DeleteClinic(clinicId);

            switch (deleted.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<bool>.Success(deleted.Data, "Clinic updated successfully.");

                case DataLayerResult.Conflict:
                    return OperationResult<bool>.NotFound("Clinic not found or nothing to update.");

                default:
                    return OperationResult<bool>.InternalError($"Unexpected error: {deleted.Message}");
            }
            
            
        }

        public async Task<OperationResult<Clinic>> GetClinicById(int clinicId)
        {if(clinicId<=0) return OperationResult<Clinic>.ValidationError($"id not valid");


            var clinic = await _repo.GetClinicById(clinicId);
            switch (clinic.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<Clinic>.Success(new Clinic(clinic.Data), "operation is  successfully.");

                case DataLayerResult.Conflict:
                    return OperationResult<Clinic>.NotFound("Clinic not found or nothing to update.");

                default:
                    return OperationResult<Clinic>.InternalError($"Unexpected error: {clinic.Message}");
            }
           
              
        }

        public async Task<OperationResult<List<Clinic>>> GetAllClinics()
        {
            var clinics = await _repo.GetAllClinics();
            switch (clinics.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<List<Clinic>>.Success(Clinic.ClinicEntityListToClinic(clinics.Data), "Clinic updated successfully.");

                case DataLayerResult.Conflict:
                    return OperationResult<List<Clinic>>.NotFound("Clinic not found or nothing to update.");

                default:
                    return OperationResult<List<Clinic>>.InternalError($"Unexpected error: {clinics.Message}");
            }
           
             
        }
    }
} 

