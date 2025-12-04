namespace DataLayer.Contract
{
    using DataLayer.Data;
    using DataLayer.Entities;
    using System.Collections.Generic;

    public interface IAppointmentTypeRepository
    {
       public Task  <DataLayerOperationResult<int>> AddAppointmentType(AppointmentTypeEntity entity);
       public Task  <DataLayerOperationResult<bool>> UpdateAppointmentType(AppointmentTypeEntity entity);
       public Task <DataLayerOperationResult<bool >>DeleteAppointmentType(int id);
       public Task <DataLayerOperationResult<AppointmentTypeEntity>>GetAppointmentTypeById(int id);
       public Task  <DataLayerOperationResult<List<AppointmentTypeEntity>>> GetAllAppointmentTypes();
    }

 
}
