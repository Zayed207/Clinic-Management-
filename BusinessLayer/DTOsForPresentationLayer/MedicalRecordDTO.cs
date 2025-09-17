namespace APILayer.DTOs___Validations
{
    public class MedicalRecordRequestDTO
    {
        public int MRN_ID { get; set; }
        public int PatientID_FK { get; set; }
        public string BloodType { get; set; }
        public string ChronicDiseases { get; set; }
        public DateTime IssueDate { get; set; }
        
        public string Notes { get; set; }


    }

    public class MedicalRecordResponseDTO
    {
        public int MRN_ID { get; set; }
        public int PatientID_FK { get; set; }
        public int PatientName { get; set; }
        public string BloodType { get; set; }
        public string ChronicDiseases { get; set; }
        public DateTime IssueDate { get; set; }
 
        public string Notes { get; set; }


    }
}
