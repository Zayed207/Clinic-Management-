using DataLayer.Entities;

namespace DataLayer.Contract
{
    using System.Collections.Generic;

    public interface IPaymentProviderRepository
    {
        int AddPaymentProvider(PaymentProviderEntity entity);
        bool UpdatePaymentProvider(PaymentProviderEntity entity);
        bool DeletePaymentProvider(int id);
       
    }
}
