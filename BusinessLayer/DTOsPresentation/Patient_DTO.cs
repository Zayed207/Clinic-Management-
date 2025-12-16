using BusinessLayer;
using DataLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOsPresentation
{

    public class PatientRequestDTO
    {



        public int PatientPersonID { get; set; }

        public string EmergencyContactName { get; set; }

        public string EmergencyContactPhone { get; set; }

        public DateOnly RegisterDatew { get; set; }



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
