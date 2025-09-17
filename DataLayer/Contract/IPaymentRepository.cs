using DataLayer.Entities;

namespace DataLayer.Contract
{
    using System.Collections.Generic;

    public interface IPaymentRepository
    {
        int AddPayment(PaymentEntity entity);
        bool UpdatePayment(PaymentEntity entity);
        bool DeletePayment(int id);
        
    }
}
