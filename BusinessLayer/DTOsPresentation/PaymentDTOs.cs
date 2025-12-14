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
        public int AppointmentID { get; set; }
        public int? FromAccountID { get; set; }
        public int? ToAccountID { get; set; }
        public short? ProviderID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; }



    }

  
}
