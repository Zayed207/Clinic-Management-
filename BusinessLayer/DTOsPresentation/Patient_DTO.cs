using BusinessLayer;
using DataLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace APILayer.DTOs___Validations
{
    public class PatientResponseDTO
    {
        public int PatientID { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int PatientPersonID { get; set; }
        
        public int Patient_MR_ID { get; set; }

        public string EmergencyContactName { get; set; }
       
        public string EmergencyContactPhone { get; set; }

        public DateOnly RegisterDatew { get; set; }



        public PatientResponseDTO(Patient DTO)
        {
            PatientID = DTO.PatientID;
            PatientPersonID = DTO.PatientPersonID;

            EmergencyContactName = DTO.EmergencyContactName;
            EmergencyContactPhone = DTO.EmergencyContactPhone;
            RegisterDatew = DTO.RegisterDatew;



        }


        
    }

    public class PatientRequestDTO
    {



        public int UserID { get; set; }
        public string EmergencyContactName { get; set; }

        public string EmergencyContactPhone { get; set; }

        public DateOnly RegisterDatew { get; set; }



    }
    public class UpdatePatientRequestDTO
    {
        public int UserID { get; set; }
        public int PatientPersonID { get; set; }
       
        public string EmergencyContactName { get; set; }

        public string EmergencyContactPhone { get; set; }

        public DateTime RegisterDatew { get; set; }



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
