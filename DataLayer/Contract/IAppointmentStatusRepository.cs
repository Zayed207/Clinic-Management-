namespace DataLayer.Contract
{
    using System.Collections.Generic;

    public interface IAppointmentStatusRepository
    {
        Task< int >AddAppointmentStatus(AppointmentStatusEntity entity);
        Task< bool >UpdateAppointmentStatus(AppointmentStatusEntity entity);
        Task< bool >DeleteAppointmentStatus(int id);
        Task< AppointmentStatusEntity>? GetAppointmentStatusById(int id);
       Task< List<AppointmentStatusEntity> >GetAllAppointmentStatuses();
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
