using DataLayer.Entities;

namespace DataLayer.Contract
{
    using System.Collections.Generic;

    public interface IClinicRepository
    {
        Task <int >AddClinic(ClinicEntity entity);
        Task  <bool>UpdateClinic(ClinicEntity entity);
        Task <bool> DeleteClinic(int id);
        Task  <ClinicEntity> GetClinicById(int clinicId);
        Task <List<ClinicEntity> >GetAllClinics();

    }

    //public interface IPayPalRepository
    //{
    //    int AddPayPal(PayPalEntity entity);
    //    bool UpdatePayPal(PayPalEntity entity);
    //    bool DeletePayPal(int id);
    //    PayPalEntity? GetPayPalById(int id);
    //    List<PayPalEntity> GetAllPayPals();
    //}
}
