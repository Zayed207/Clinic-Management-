using DataLayer.Entities;

namespace DataLayer.Contract
{
    using DataLayer.Data;
    using System.Collections.Generic;

  
        public interface IPaymentRepository
        {
           public Task<DataLayerOperationResult<int>> AddPayment(PaymentEntity payment);
           
           public Task<DataLayerOperationResult<bool>> UpdatePayment(PaymentEntity payment);
        
           public Task<DataLayerOperationResult<bool>> DeletePayment(int paymentId);
          
           public Task<DataLayerOperationResult<PaymentEntity>> GetPaymentById(int paymentId);
         
           public Task<DataLayerOperationResult<List<PaymentEntity>>> GetAllPayments();
          
           public Task<DataLayerOperationResult<List<PaymentEntity>>> GetAllPaymentsForPatient(int patientPersonId);
        
           public Task<DataLayerOperationResult<List<PaymentEntity>>> GetAllPaymentsForDoctor(int doctorId);
        }


    
}
