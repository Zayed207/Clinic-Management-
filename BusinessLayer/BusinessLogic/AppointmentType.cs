using AutoMapper;
using BusinessLayer;
using BusinessLayer.BusinessLogic;
using DataLayer.Contract;
using DataLayer.Entities;
using System.Threading.Tasks;

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
        try
        {
            var a = _mapper.Map<AppointmentTypeEntity>(dto);
            int id =await _repo.AddAppointmentType(a);

            if (id > 0)
                return OperationResult<int>.Success(id, "Appointment type created successfully.");

            return OperationResult<int>.InternalError("Failed to create appointment type.");
        }
        catch (Exception ex)
        {
            return OperationResult<int>.InternalError($"Unexpected error: {ex.Message}");
        }
    }

    public async Task<OperationResult<bool>> UpdateAppointmentType(AppointmentTypeDTO dto)
    {
        try
        {
            bool updated =await _repo.UpdateAppointmentType(_mapper.Map<AppointmentTypeEntity>(dto));

            if (updated)
                return OperationResult<bool>.Updated("Appointment type updated successfully.");

            return OperationResult<bool>.NotFound("Appointment type not found.");
        }
        catch (Exception ex)
        {
            return OperationResult<bool>.InternalError($"Unexpected error: {ex.Message}");
        }
    }

    public async Task<OperationResult<bool>> DeleteAppointmentType(int id)
    {
        try
        {
            bool deleted =await _repo.DeleteAppointmentType(id);

            if (deleted)
                return OperationResult<bool>.Success(true, "Appointment type deleted successfully.");

            return OperationResult<bool>.NotFound("Appointment type not found.");
        }
        catch (Exception ex)
        {
            return OperationResult<bool>.InternalError($"Unexpected error: {ex.Message}");
        }
    }

    public async Task<OperationResult<AppointmentType>> GetAppointmentTypeById(int id)
    {
        try
        {
            var entity =await _repo.GetAppointmentTypeById(id);

            if (entity == null)
                return OperationResult<AppointmentType>.NotFound("Appointment type not found.");

            return OperationResult<AppointmentType>.Success(new AppointmentType(entity));
        }
        catch (Exception ex)
        {
            return OperationResult<AppointmentType>.InternalError($"Unexpected error: {ex.Message}");
        }
    }

    public async Task<OperationResult<List<AppointmentType>>> GetAllAppointmentTypes()
    {
        try
        {
            var list =await _repo.GetAllAppointmentTypes();

            if (list == null || list.Count == 0)
                return OperationResult<List<AppointmentType>>.NotFound("No appointment types found.");

            var types = list.Select(s => new AppointmentType(s)).ToList();
            return OperationResult<List<AppointmentType>>.Success(types);
        }
        catch (Exception ex)
        {
            return OperationResult<List<AppointmentType>>.InternalError($"Unexpected error: {ex.Message}");
        }
    }
}