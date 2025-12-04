using DataLayer.Contract;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class PaymentProviderData:IPaymentProviderRepository
    {
		private readonly Clinicdbcontext _context;
		public PaymentProviderData(Clinicdbcontext context)
		{
			_context = context;
		}
		public  async Task<DataLayerOperationResult<int>> AddProvider(PaymentProviderEntity provider)
        {
          
                
                
            
            try
            {





                _context.PaymentProviders.Add(provider);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<int>.SuccessOperation(provider.ProviderID);


                return DataLayerOperationResult<int>.Fail("adding not successfuly");




            }

            catch (Exception ex)
            {

                return DataLayerOperationResult<int>.InternalError();

            }
        }

        public  async Task<DataLayerOperationResult<bool>> UpdateProvider(PaymentProviderEntity provider)
        {
           
            try

            {

                var exsit = await _context.PaymentProviders.FindAsync(provider.ProviderID);
                if (exsit == null)
                {
                    return DataLayerOperationResult<bool>.Fail("this employee is not exist");

                }



                _context.PaymentProviders.Update(provider);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("woring!!");




            }

            catch (Exception ex)
            {

                return DataLayerOperationResult<bool>.InternalError();

            }
        }

        public  async Task<DataLayerOperationResult<bool>> DeleteProviderByID(int providerId)
        {
           
            try

            {

                var provider = _context.PaymentProviders.Find(providerId);
                if (provider == null)
                {
                    return DataLayerOperationResult<bool>.Fail("this doctor is not exist");

                }



                _context.PaymentProviders.Remove(provider);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("deleting is not successfuly");




            }

            catch (Exception ex)
            {

                return DataLayerOperationResult<bool>.InternalError();

            }
        }

        public  PaymentProviderEntity GetProviderById(int providerId)
        {
          
                 _context.PaymentProviders.FirstOrDefault(x => x.ProviderID == providerId);
            throw new NotImplementedException();

        }

        public  List<PaymentProviderEntity> GetAllProviders()
        {
          
                return _context.PaymentProviders.AsNoTracking().ToList();
            
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
