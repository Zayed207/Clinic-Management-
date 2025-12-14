using DataLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOsPresentation.DoctorDTO
{
 public class DoctorResposeDTO
    {
        
         public string FullName { get; set; }
        public string UserName { get; set; }

        public int EmployeeID{ get; set; }
        
        public string Title { get; set; } 
        public string MedicalLicenseNumber { get; set; }
        public int? Years_of_Experience { get; set; }
        public string ClinicName { get; set; }
        public bool? Is_On_Call { get; set; }
        public string Specialization { get; set; }
        public int DoctorTypeName { get; set; }

        public decimal Price { get; set; }

     

    }

}

