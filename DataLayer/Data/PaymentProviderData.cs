using DataLayer.Contract;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Data
{
    public class PaymentProviderData:IPaymentProviderRepository
    {
		private readonly Clinicdbcontext _context;
		public PaymentProviderData(Clinicdbcontext context)
		{
			_context = context;
		}
		public  int AddProvider(PaymentProviderEntity provider)
        {
            using (_context )
            {
                _context.PaymentProviders.Add(provider);
                _context.SaveChanges();
                return provider.ProviderID;
            }
        }

        public  bool UpdateProvider(PaymentProviderEntity provider)
        {
            using (_context)
            {
                _context.PaymentProviders.Update(provider);
                return _context.SaveChanges() > 0;
            }
        }

        public  bool DeleteProvider(int providerId)
        {
            using (_context)
            {
                var provider = _context.PaymentProviders.Find(providerId);
                if (provider == null) return false;
                _context.PaymentProviders.Remove(provider);
                return _context.SaveChanges() > 0;
            }
        }

        public  PaymentProviderEntity GetProviderById(int providerId)
        {
            using (_context )
            {
                return _context.PaymentProviders.FirstOrDefault(x => x.ProviderID == providerId);
            }
        }

        public  List<PaymentProviderEntity> GetAllProviders()
        {
            using (_context)
            {
                return _context.PaymentProviders.AsNoTracking().ToList();
            }
        }

        public int AddPaymentProvider(PaymentProviderEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePaymentProvider(PaymentProviderEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool DeletePaymentProvider(int id)
        {
            throw new NotImplementedException();
        }
    }
}
