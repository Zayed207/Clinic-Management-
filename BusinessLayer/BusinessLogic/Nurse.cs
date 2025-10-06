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
    public class Nurse
    {

        public int NurseID { get; set; }
        public int Employee_ID_FK { get; set; }
      
        public int ClinicID_FK { get; set; }

        public Nurse(NurseEntity nurse)
        {
            NurseID = nurse.NurseID;
            Employee_ID_FK = nurse.Employee_ID_FK;
            
            nurse.ClinicID_FK = nurse.ClinicID_FK;
        }

        public Nurse(NurseRequestDTO nurse)
        {
            NurseID = nurse.NurseID;
            Employee_ID_FK = nurse.Employee_ID_FK;

            nurse.ClinicID_FK = nurse.ClinicID_FK;
        }

    }

    public class NurseServices
    {
        private readonly IMapper _mapper;
        private readonly INurseRepository _repo;

        public NurseServices(INurseRepository nurse, IMapper mapper)
        {
            _mapper = mapper;
            _repo = nurse;
        }

        public async Task<OperationResult<int>> AddNewNurse(NurseRequestDTO nurse)
        {
            try
            {
                var entity = _mapper.Map<NurseEntity>(new Nurse(nurse));
                var newId =await _repo.AddNurse(entity);

                if (newId > 0)
                    return OperationResult<int>.Success(newId);

                return OperationResult<int>.Conflict("Nurse could not be added.");
            }
            catch (Exception ex)
            {
                return OperationResult<int>.InternalError(ex.Message);
            }
        }

        public async Task<OperationResult<string>> UpdateNurse(NurseRequestDTO nurse)
        {
            try
            {
                var updated =await _repo.UpdateNurse(_mapper.Map<NurseEntity>(new Nurse(nurse)));
                if (updated)
                    return OperationResult<string>.Updated("Nurse updated successfully.");

                return OperationResult<string>.NotFound("Nurse not found.");
            }
            catch (Exception ex)
            {
                return OperationResult<string>.InternalError(ex.Message);
            }
        }

        public async Task<OperationResult<string>> DeleteNurse(int nurseId)
        {
            try
            {
                var deleted =await _repo.DeleteNurse(nurseId);
                if (deleted)
                    return OperationResult<string>.Success("Nurse deleted successfully.");

                return OperationResult<string>.NotFound("Nurse not found.");
            }
            catch (Exception ex)
            {
                return OperationResult<string>.InternalError(ex.Message);
            }
        }

        public async Task<OperationResult<Nurse>> GetNurseById(int nurseId)
        {
            try
            {
                var entity =await _repo.GetNurseById(nurseId);
                if (entity == null)
                    return OperationResult<Nurse>.NotFound("Nurse not found.");

                return OperationResult<Nurse>.Success(new Nurse(entity));
            }
            catch (Exception ex)
            {
                return OperationResult<Nurse>.InternalError(ex.Message);
            }
        }


    }
}
