using DataLayer.ReadModel.Patient;

namespace BusinessLayer.DTOsPresentation
{
    public class PatientInfoDTO
    {
        public int PatientID { get; set; }
        public int UserID { get; set; }
        public string FullName { get; set; } = string.Empty;

        public int PatientPersonID { get; set; }

        public int LastMedicalRecordID { get; set; }

        public string EmergencyContactName { get; set; } = string.Empty;
        public string EmergencyContactPhone { get; set; } = string.Empty;

        public DateOnly RegisterDatew { get; set; }

       
        public PatientInfoDTO(PatientInfo data)
        {
            PatientID = data.PatientID;
            UserID = data.UserID;
            FullName = data.FullName;
            PatientPersonID = data.PatientPersonID;
            LastMedicalRecordID = data.LastMedicalRecordID;
            EmergencyContactName = data.EmergencyContactName;
            EmergencyContactPhone = data.EmergencyContactPhone;
            RegisterDatew = data.RegisterDatew;
        }

        // static converter (الأسلوب الموحد)
        public static PatientInfoDTO FromData(PatientInfo data)
            => new PatientInfoDTO(data);



    }
    
    //public class PatientSummaryDTOs
    //{
    //    public int PatientID { get; set; }
    //    public string FullName { get; set; }
    //    public string Gender { get; set; }
    //    public short Age { get; set; }
    //    public DateTime LastAppointmentDate { get; set; }
    //    public string AppointmentTypeName { get; set; }

    //    public List<MedicalRecordSummary> MedicalRecords { get; set; } = new();

    //    public PatientSummaryDTOs(PatientSummary PatientInfo)
    //    {
    //        PatientID = PatientInfo.PatientID;
    //        FullName = PatientInfo.FullName;
    //        Gender = PatientInfo.Gender;
    //        Age = PatientInfo.Age;
    //        LastAppointmentDate = PatientInfo.LastAppointmentDate;
    //        AppointmentTypeName = PatientInfo.AppointmentTypeName;
    //        MedicalRecords = PatientInfo.MedicalRecords;
    //    }
    //}


}
