using DataLayer.Contract;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;
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

		public  async Task<DataLayerOperationResult<int>> AddPayment(PaymentEntity method)
        {

           
            try
            {






                _context.Payment.Add(method);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<int>.SuccessOperation(method.PaymentID);


                return DataLayerOperationResult<int>.Fail("adding not successfuly");




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/AddPayment ", ex);

                return DataLayerOperationResult<int>.InternalError();

            }
        }

        public  async Task<DataLayerOperationResult<bool>> UpdatePayment(PaymentEntity method)
        {
           
                
            try

            {

                var exsit = await _context.Employees.FindAsync(method.PaymentID);
                if (exsit == null)
                {
                    return DataLayerOperationResult<bool>.Fail("this payment is not exist");

                }



                _context.Payment.Update(method);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("woring!!");




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/UpdatePayment ", ex);

                return DataLayerOperationResult<bool>.InternalError();

            }
        }

        public  async Task<DataLayerOperationResult<bool>> DeletePayment(int methodId)
        {
            
               
               
            try

            {


                var method =await _context.Payment.FindAsync(methodId);
                if (method == null)
                {
                    return DataLayerOperationResult<bool>.Fail("this paymentid is not exist");

                }



                _context.Payment.Remove(method);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("deleting is not successfuly");




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/DeletePayment ", ex);

                return DataLayerOperationResult<bool>.InternalError();

            }
        }

        public  async Task<DataLayerOperationResult<PaymentEntity>> GetPaymentById(int methodId)
        {
            



            try

            {


                var method = await  _context.Payment.FirstOrDefaultAsync(x => x.PaymentID == methodId);
                if (method == null)
                {
                    return DataLayerOperationResult<PaymentEntity>.Fail("this paymentid is not exist");

                }



                return DataLayerOperationResult<PaymentEntity>.SuccessOperation(method);


             




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/GetPaymentById ", ex);


                return DataLayerOperationResult<PaymentEntity>.InternalError();

            }
            ;
            
        }

        public  async Task<DataLayerOperationResult<List<PaymentEntity>>> GetAllPayments()
        {
          
                
                try

                {
                    var allpayments = await _context.Payment.AsNoTracking().ToListAsync();
                if (allpayments == null || allpayments.Count == 0) return DataLayerOperationResult<List<PaymentEntity>>.Fail("No employees avaliable");



                    return DataLayerOperationResult<List<PaymentEntity>>.SuccessOperation(allpayments);

                }

                catch (Exception ex)
                {

                    return DataLayerOperationResult<List<PaymentEntity>>.InternalError();

                }
            }
        public async Task<DataLayerOperationResult<List<PaymentEntity>>> GetAllPaymentsForPatient(int personid)
        {


            try

            {
                var allpayments = await _context.Payment.Where(x=>x.PatientPersonID_FK==personid) .AsNoTracking().ToListAsync();
                if (allpayments == null || allpayments.Count == 0) return DataLayerOperationResult<List<PaymentEntity>>.Fail("this personid dosen't has any payment");



                return DataLayerOperationResult<List<PaymentEntity>>.SuccessOperation(allpayments);

            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/GetAllPaymentForPatient ", ex);

                return DataLayerOperationResult<List<PaymentEntity>>.InternalError();

            }
        }
        public async Task<DataLayerOperationResult<List<PaymentEntity>>> GetAllPaymentsForDoctor(int doctorid)
        {


            try

            {
                var allpayments = await _context.Payment.Where(x => x.DoctorID_FK == doctorid).AsNoTracking().ToListAsync();
                if (allpayments == null || allpayments.Count == 0) return DataLayerOperationResult<List<PaymentEntity>>.Fail("this doctor dosen't has any payment");



                return DataLayerOperationResult<List<PaymentEntity>>.SuccessOperation(allpayments);

            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/GetAllPaymentForDoctor ", ex);

                return DataLayerOperationResult<List<PaymentEntity>>.InternalError();

            }
        }

        
    }
}
