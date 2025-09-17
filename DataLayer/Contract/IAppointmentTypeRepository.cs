namespace DataLayer.Contract
{
    using System.Collections.Generic;

    public interface IAppointmentTypeRepository
    {
        int AddAppointmentType(AppointmentTypeEntity entity);
        bool UpdateAppointmentType(AppointmentTypeEntity entity);
        bool DeleteAppointmentType(int id);
        AppointmentTypeEntity GetAppointmentTypeById(int id);
        List<AppointmentTypeEntity> GetAllAppointmentTypes();
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
