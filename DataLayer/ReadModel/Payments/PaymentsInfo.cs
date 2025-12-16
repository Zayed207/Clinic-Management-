using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ReadModel.Payments
{
    public class PaymentInfo
    {
        public int PaymentID { get; set; }

        public int AppointmentID_FK { get; set; }

        public string DoctorName { get; set; } = string.Empty;

        public string PatientPersonName { get; set; } = string.Empty;

        public short ProviderID_FK { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public string Status { get; set; } = string.Empty;
    }

}
