using BusinessLayer;
using System.ComponentModel.DataAnnotations;

namespace APILayer.DTOs___Validations
{
    public class PatientResponseDTO
    {
        public int PatientID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int PatientPersonID { get; set; }
        
        public int Patient_MR_ID { get; set; }

        public string EmergencyContactName { get; set; }
       
        public string EmergencyContactPhone { get; set; }

        public DateTime RegisterDatew { get; set; }



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

       

        public int PatientPersonID { get; set; }
       
        public string EmergencyContactName { get; set; }

        public string EmergencyContactPhone { get; set; }

        public DateTime RegisterDatew { get; set; }



    }
    public class UpdatePatientRequestDTO
    {
        public int PatientID { get; set; }
        public int PatientPersonID { get; set; }
       
        public string EmergencyContactName { get; set; }

        public string EmergencyContactPhone { get; set; }

        public DateTime RegisterDatew { get; set; }



    }


}
