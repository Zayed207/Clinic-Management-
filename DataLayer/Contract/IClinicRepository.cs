using DataLayer.Entities;

namespace DataLayer.Contract
{
    using DataLayer.Data;
    using System.Collections.Generic;

    public interface IClinicRepository
    {
       public Task <DataLayerOperationResult<int> >AddClinic(ClinicEntity entity);
       public Task  <DataLayerOperationResult<bool>>UpdateClinic(ClinicEntity entity);
       public Task <DataLayerOperationResult<bool>> DeleteClinic(int id);
       public Task  <DataLayerOperationResult<ClinicEntity>> GetClinicById(int clinicId);
       public Task <DataLayerOperationResult<List<ClinicEntity> >>GetAllClinics();

    }


}
