using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOsPresentation
{
    public class PaymentRequestDTO
    {
      
        public int AppointmentID { get; set; }
        public int ?FromAccountID { get; set; }
        public int ?ToAccountID { get; set; }
        public short? ProviderID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; }

      

    }


        public class PaymentResponseDTO
        {
            public int PaymentID { get; set; }

            public int AppointmentID_FK { get; set; }

            public string DoctorName { get; set; } = string.Empty;

            public string PatientPersonName { get; set; } = string.Empty;

            public short ProviderID_FK { get; set; }

            public decimal Amount { get; set; }

            public DateTime PaymentDate { get; set; }

            public string Status { get; set; } = string.Empty;

            //public PaymentResponseDTO(PaymentInfo data)
            //{
            //    PaymentID = data.PaymentID;
            //    AppointmentID_FK = data.AppointmentID_FK;
            //    DoctorName = data.DoctorName;
            //    PatientPersonName = data.PatientPersonName;
            //    ProviderID_FK = data.ProviderID_FK;
            //    Amount = data.Amount;
            //    PaymentDate = data.PaymentDate;
            //    Status = data.Status;
            //}

           
            //public static PaymentResponseDTO FromPaymentInfo(PaymentInfo data)
            //    => new PaymentResponseDTO(data);
        




    }


}
