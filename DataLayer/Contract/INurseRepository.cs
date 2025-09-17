using DataLayer.Entities;

namespace DataLayer.Contract
{
    using System.Collections.Generic;

    public interface INurseRepository
    {
      Task  <int> AddNurse(NurseEntity entity);
      Task  <bool> UpdateNurse(NurseEntity entity);
      Task  <bool >DeleteNurse(int id);
      Task  <NurseEntity> GetNurseById(int nurseId);
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
