using DataLayer.Entities;

namespace DataLayer.Contract
{
    using System.Collections.Generic;

    public interface IAccountRepository
    {
        int AddAccount(AccountEntity entity);
        bool UpdateAccount(AccountEntity entity);
        bool DeleteAccount(int id);
        AccountEntity? GetAccountById(int id);
        List<AccountEntity> GetAllAccounts();
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
