using AutoMapper;
using BusinessLayer;
using BusinessLayer.BusinessLogic;
using DataLayer.Contract;
using DataLayer.Data;
using DataLayer.Entities;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

public class AppointmentType
{
    

    public int Type_ID { get; set; }
    public string Type_Name { get; set; }
    public string Description { get; set; }

    public AppointmentType(AppointmentTypeEntity ATE)
    {
        Type_ID = ATE.TypeID;
        Type_Name = ATE.TypeName;
        Description = ATE.Description;
    }
}
public class AppointmentTypeServices 
{
    private readonly IAppointmentTypeRepository _repo;
    private readonly IMapper _mapper;

    public AppointmentTypeServices(IAppointmentTypeRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<OperationResult<int>> AddAppointmentType(AppointmentTypeDTO dto)
    {

        var id = await _repo.AddAppointmentType(_mapper.Map<AppointmentTypeEntity>(dto));

        switch (id.ResultType)
        {
            case DataLayerResult.Success:
                return OperationResult<int>.Success(id.Data, " new Appointmenttype  created successfully.");

            case DataLayerResult.Conflict:
                return OperationResult<int>.Conflict("unsuccessfully added");

            default:
                return OperationResult<int>.InternalError($"Unexpected error: {id.Message}");
        }

    }
    public async Task<OperationResult<bool>> UpdateAppointmentType(AppointmentTypeDTO dto)
    {
        
            var updated =await _repo.UpdateAppointmentType(_mapper.Map<AppointmentTypeEntity>(dto));

            switch (updated.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<bool>.Success(updated.Data, " Appointment type updated successfully.");

                case DataLayerResult.Conflict:
                    return OperationResult<bool>.Conflict("Appointment type not found");

                default:
                    return OperationResult<bool>.InternalError($"Unexpected error: {updated.Message}");
            }
           
    }

    public async Task<OperationResult<bool>> DeleteAppointmentType(int id)
    {
       
            var deleted = await _repo.DeleteAppointmentType(id);
            switch (deleted.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<bool>.Success(deleted.Data, " Appointment type deleted successfully.");

                case DataLayerResult.Conflict:
                    return OperationResult<bool>.Conflict("Appointment type not found");

                default:
                    return OperationResult<bool>.InternalError($"Unexpected error: {deleted.Message}");
            }

        }
        
    public async Task<OperationResult<AppointmentType>> GetAppointmentTypeById(int id)
    {
        
            var entity =await _repo.GetAppointmentTypeById(id);
            switch (entity.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<AppointmentType>.Success(new AppointmentType(entity.Data));

                case DataLayerResult.Conflict:
                    return OperationResult<AppointmentType>.Conflict("Appointment type not found");

                default:
                    return OperationResult<AppointmentType>.InternalError($"Unexpected error: {entity.Message}");
            }

    }

    public async Task<OperationResult<List<AppointmentType>>> GetAllAppointmentTypes()
    {
       
            var list =await _repo.GetAllAppointmentTypes();
        if (list.ResultType == DataLayerResult.Conflict)
            return OperationResult<List<AppointmentType>>.NotFound("No appointmenttypes found ");

        if (list.ResultType == DataLayerResult.InternalError)
            return OperationResult<List<AppointmentType>>.InternalError($"Unexpected error: {list.Message}");

        var mapped = list.Data.Select(a => new AppointmentType(a)).ToList();
        return OperationResult<List<AppointmentType>>.Success(mapped);
      
    }
}