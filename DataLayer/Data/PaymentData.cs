using DataLayer.Contract;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class PaymentData:IPaymentRepository
    {
		private readonly Clinicdbcontext _context;
		public PaymentData(Clinicdbcontext context)
		{
			_context = context;
		}

		public  int AddPayment(PaymentEntity method)
        {
            using (_context )
            {
                _context.Payment.Add(method);
                _context.SaveChanges();
                return method.PaymentID;
            }
        }

        public  bool UpdatePayment(PaymentEntity method)
        {
            using (_context)
            {
                _context.Payment.Update(method);
                return _context.SaveChanges() > 0;
            }
        }

        public  bool DeletePayment(int methodId)
        {
            using (_context)
            {
                var method = _context.Payment.Find(methodId);
                if (method == null) return false;
                _context.Payment.Remove(method);
                return _context.SaveChanges() > 0;
            }
        }

        public  PaymentEntity GetPaymentById(int methodId)
        {
            using (_context )
            {
                return _context.Payment.FirstOrDefault(x => x.PaymentID == methodId);
            }
        }

        //public static List<PaymentEntity> GetAllPayment()
        //{
        //    using (var _context = new Clinicdb_context())
        //    {
        //        return _context.Payment.AsNoTracking().ToList();
        //    }
        //}

    }
}
