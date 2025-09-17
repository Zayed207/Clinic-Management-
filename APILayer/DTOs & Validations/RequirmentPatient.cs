using BusinessLayer;

namespace APILayer.DTOs___Validations
{
    public class PatientResponseDTO
    {
        public int PatientID { get; set; }

        public int PatientPersonID { get; set; }

        public int Patient_MR_ID { get; set; }

        public string EmergencyContactName { get; set; }

        public string EmergencyContactPhone { get; set; }

        public DateOnly RegisterDatew { get; set; }

      

        PatientResponseDTO(clsPatient DTO)
        {
            PatientID = DTO.PatientID;
            PatientPersonID = DTO.PatientPersonID;
            
            EmergencyContactName = DTO.EmergencyContactName;
            EmergencyContactPhone = DTO.EmergencyContactPhone;
            RegisterDatew = DTO.RegisterDatew;



        }


        //public bool Validations(clsPatient Check)
        //{




        //}

    }

    public class PatientRequestDTO
    {

        public string EmergencyContactName { get; set; }

        public string EmergencyContactPhone { get; set; }

        public DateOnly RegisterDatew { get; set; }

        public PatientRequestDTO(int patientPersonID, int patient_MR_ID,
           string emergencyContactName, string emergencyContactPhone, DateOnly registerDatew)
        {

            EmergencyContactName = emergencyContactName;
            EmergencyContactPhone = emergencyContactPhone;
            RegisterDatew = registerDatew;
        }

    }

        public class RequirmentPatient
        {

            //public bool Validations(clsPatient Check)
            //{




            //}





        }
    }
