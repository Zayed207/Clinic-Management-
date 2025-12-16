using DataLayer.ReadModel.MedicalRecord;

namespace BusinessLayer.DTOsPresentation
{
    public class MedicalRecordRequestDTO
    {
        public int MRN_ID { get; set; }
        public int PatientID_FK { get; set; }
        public string BloodType { get; set; }
        public string ChronicDiseases { get; set; }
        public DateOnly IssueDate { get; set; }
        
        public string Notes { get; set; }


    }

    public class MedicalRecordInfoDTO
    {
        public int MRN_ID { get; set; }
        public int PatientID_FK { get; set; }
        public string PatientName { get; set; } = string.Empty;

        public string BloodType { get; set; } = string.Empty;
        public string ChronicDiseases { get; set; } = string.Empty;
        public DateTime IssueDate { get; set; }

        public string? Notes { get; set; }

        // constructor mapping
        public MedicalRecordInfoDTO(MedicalRecordInfo data)
        {
            MRN_ID = data.MRN_ID;
            PatientID_FK = data.PatientID_FK;
            PatientName = data.PatientName;
            BloodType = data.BloodType;
            ChronicDiseases = data.ChronicDiseases;
            IssueDate = data.IssueDate;
            Notes = data.Notes;
        }

        // static converter (أسلوبك الموحد)
        public static MedicalRecordInfoDTO FromMedicalRecordInfo(MedicalRecordInfo data)
            => new MedicalRecordInfoDTO(data);
    }

}
