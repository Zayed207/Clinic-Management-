using AutoMapper;
using BusinessLayer;
using BusinessLayer.BusinessLogic;
using DataLayer.Contract;
using DataLayer.Entities;
using System.Threading.Tasks;



public class AppointmentStatus
{
    public enum enAppointmentStatus { Compelete = 1, Cancelled = 2, Pending = 3 }
    public int Status_ID { get; set; }
    public string Status_Name { get; set; }
    public string Description { get; set; }

    public AppointmentStatus(AppointmentStatusEntity ASE)
    {
        Status_ID = ASE.Status_ID;
        Status_Name = ASE.Status_Name;
        Description = ASE.Description;
    }
}
public class AppointmentStatusServices
{


    private readonly IAppointmentStatusRepository _repo;
    private readonly IMapper _mapper;

    public AppointmentStatusServices(IAppointmentStatusRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<OperationResult<int>> AddAppointmentStatus(AppointmentStatusDTOs dto)
    {
        try
        {
            int id =await _repo.AddAppointmentStatus(_mapper.Map<AppointmentStatusEntity>(dto));

            if (id > 0)
                return OperationResult<int>.Success(id, "Appointment status created successfully.");

            return OperationResult<int>.InternalError("Failed to create appointment status.");
        }
        catch (Exception ex)
        {
            return OperationResult<int>.InternalError($"Unexpected error: {ex.Message}");
        }
    }

    public async Task<OperationResult<bool>> UpdateAppointmentStatus(AppointmentStatusDTOs dto)
    {
        try
        {
            bool updated =await _repo.UpdateAppointmentStatus(_mapper.Map<AppointmentStatusEntity>(dto));

            if (updated)
                return OperationResult<bool>.Updated("Appointment status updated successfully.");

            return OperationResult<bool>.NotFound("Appointment status not found.");
        }
        catch (Exception ex)
        {
            return OperationResult<bool>.InternalError($"Unexpected error: {ex.Message}");
        }
    }

    public async Task<OperationResult<bool>> DeleteAppointmentStatus(int id)
    {
        try
        {
            bool deleted =await _repo.DeleteAppointmentStatus(id);

            if (deleted)
                return OperationResult<bool>.Success(true, "Appointment status deleted successfully.");

            return OperationResult<bool>.NotFound("Appointment status not found.");
        }
        catch (Exception ex)
        {
            return OperationResult<bool>.InternalError($"Unexpected error: {ex.Message}");
        }
    }

    public async Task <OperationResult<AppointmentStatus> >GetAppointmentStatusById(int id)
    {
        try
        {
            var entity = await _repo.GetAppointmentStatusById(id);

            if (entity == null)
                return OperationResult<AppointmentStatus>.NotFound("Appointment status not found.");

            return OperationResult<AppointmentStatus>.Success(new AppointmentStatus(entity));
        }
        catch (Exception ex)
        {
            return OperationResult<AppointmentStatus>.InternalError($"Unexpected error: {ex.Message}");
        }
    }

    public async Task <OperationResult<List<AppointmentStatus>> >GetAllAppointmentStatuses()
    {
        try
        {
            var list = await _repo.GetAllAppointmentStatuses();

            if (list == null || list.Count == 0)
                return OperationResult<List<AppointmentStatus>>.NotFound("No appointment statuses found.");

            var statuses = list.Select(s => new AppointmentStatus(s)).ToList();
            return OperationResult<List<AppointmentStatus>>.Success(statuses);
        }
        catch (Exception ex)
        {
            return OperationResult<List<AppointmentStatus>>.InternalError($"Unexpected error: {ex.Message}");
        }
    }
}
