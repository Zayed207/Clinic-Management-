using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ReadModel.Patient
{
    public class PatientInfo
    {
        public int PatientID { get; set; }
        public int UserID { get; set; }
        public string FullName { get; set; } = string.Empty;

        public int PatientPersonID { get; set; }

        public int LastMedicalRecordID { get; set; }

        public string EmergencyContactName { get; set; } = string.Empty;
        public string EmergencyContactPhone { get; set; } = string.Empty;

        public DateOnly RegisterDatew { get; set; }
    }

}
