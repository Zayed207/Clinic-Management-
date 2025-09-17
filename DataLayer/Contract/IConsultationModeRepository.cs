using DataLayer.Entities;

namespace DataLayer.Contract
{
    using System.Collections.Generic;

    public interface IConsultationModeRepository
    {
        int AddConsultationMode(ConsultationModeEntity entity);
        bool UpdateConsultationMode(ConsultationModeEntity entity);
        bool DeleteConsultationMode(int id);
        public ConsultationModeEntity GetConsultationModeById(int modeId);
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
