using AutoMapper;
using BusinessLayer;
using BusinessLayer.BusinessLogic;
using DataLayer.Contract;
using DataLayer.Data;
using DataLayer.Entities;
using System.Threading.Tasks;



public class AppointmentStatus
{
   
    public int Status_ID { get; set; }
    public string Status_Name { get; set; }
    public string Description { get; set; }

    public AppointmentStatus(AppointmentStatusEntity ASE)
    {
        Status_ID = ASE.StatusID;
        Status_Name = ASE.StatusName;
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

    public async Task<OperationResult<int>> AddAppointmentStatus(AppointmentStatusRequestDTOs dto)
    {
        try
        {
            var id =await _repo.AddAppointmentStatus(_mapper.Map<AppointmentStatusEntity>(dto));

            if (id.Data > 0)
                return OperationResult<int>.Success(id.Data, "Appointment status created successfully.");

            return OperationResult<int>.InternalError("Failed to create appointment status.");
        }
        catch (Exception ex)
        {
            return OperationResult<int>.InternalError($"Unexpected error: {ex.Message}");
        }
    }

    public async Task<OperationResult<bool>> UpdateAppointmentStatus(AppointmentStatusRequestDTOs dto)
    {
        try
        {
            var updated =await _repo.UpdateAppointmentStatus(_mapper.Map<AppointmentStatusEntity>(dto));

            if (updated.ResultType == DataLayerResult.Success   )
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
            var deleted =await _repo.DeleteAppointmentStatus(id);

            if (deleted.ResultType== DataLayerResult.Success)
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

            return OperationResult<AppointmentStatus>.Success(new AppointmentStatus(entity.Data));
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

            if (list == null || list.Data.Count == 0)
                return OperationResult<List<AppointmentStatus>>.NotFound("No appointment statuses found.");

            var statuses = list.Data.Select(s => new AppointmentStatus(s)).ToList();
            return OperationResult<List<AppointmentStatus>>.Success(statuses);
        }
        catch (Exception ex)
        {
            return OperationResult<List<AppointmentStatus>>.InternalError($"Unexpected error: {ex.Message}");
        }
    }
}
