using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class MedicalRecordEntity
    {
        public int MRNID { get; set; }
        public int PatientID_FK { get; set; }
        public PatientEntity Patient { get; set; }


        public string BloodType { get; set; }
        public string ChronicDiseases { get; set; }
        public DateTime IssueDate { get; set; }
        
        public string? Notes { get; set; }


    }
}
