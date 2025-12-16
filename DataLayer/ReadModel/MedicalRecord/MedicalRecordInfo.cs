using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ReadModel.MedicalRecord
{
    public class MedicalRecordInfo
    {
        public int MRN_ID { get; set; }
        public int PatientID_FK { get; set; }
        public string PatientName { get; set; } = string.Empty;

        public string BloodType { get; set; } = string.Empty;
        public string ChronicDiseases { get; set; } = string.Empty;
        public DateTime IssueDate { get; set; }

        public string? Notes { get; set; }
    }

}
