namespace DataLayer.Contract
{
    using DataLayer.Data;
    using DataLayer.Entities;
    using System.Collections.Generic;

    public interface IAppointmentStatusRepository
    {
       public Task<DataLayerOperationResult<int >>AddAppointmentStatus(AppointmentStatusEntity entity);
       public Task<DataLayerOperationResult<bool> >UpdateAppointmentStatus(AppointmentStatusEntity entity);
       public Task<DataLayerOperationResult<bool >>DeleteAppointmentStatus(int id);
       public Task<DataLayerOperationResult<AppointmentStatusEntity>> GetAppointmentStatusById(int id);
       public Task<DataLayerOperationResult<List<AppointmentStatusEntity>> >GetAllAppointmentStatuses();
    }

  
}
