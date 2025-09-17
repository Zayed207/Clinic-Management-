using BusinessLayer;
using DataLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
 public class DoctorResposeDTO
    {
        
        public int Employee_ID_FK { get; set; }
        public string MedicalLicenseNumber { get; set; }
        public int? Years_of_Experience { get; set; }
        public String ClinicName { get; set; }
        public bool? Is_On_Call { get; set; }
        public string Specialization { get; set; }
        public int DoctorTypeName { get; set; }


        public decimal Price { get; set; }

        public DoctorResposeDTO(int employee_ID_FK, string medicalLicenseNumber,
            int? years_of_Experience, string clinicName, bool? is_On_Call, string specialization, int doctorTypeName, decimal price)
        {
            Employee_ID_FK = employee_ID_FK;
            MedicalLicenseNumber = medicalLicenseNumber;
            Years_of_Experience = years_of_Experience;
            ClinicName = clinicName;
            Is_On_Call = is_On_Call;
            Specialization = specialization;
            DoctorTypeName = doctorTypeName;
            Price = price;
        }

    }

 public class DoctorRequestDTO
        {
        [Required]
            public int Employee_ID_FK { get; set; }

        [Required]
        public string MedicalLicenseNumber { get; set; }
            public int Years_of_Experience { get; set; }
        [Required]
        public int ClinicID_FK { get; set; }
            public bool Is_On_Call { get; set; }
            public string Specialization { get; set; }
        [Required]
        public int DoctorTypeID_FK { get; set; }
            public decimal Price { get; set; }


        }
 }

