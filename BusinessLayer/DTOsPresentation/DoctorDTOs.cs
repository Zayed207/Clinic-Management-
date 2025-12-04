using BusinessLayer;
using DataLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
 public class DoctorResposeDTO
    {
        
        public int EmployeeID{ get; set; }
        public string MedicalLicenseNumber { get; set; }
        public int? Years_of_Experience { get; set; }
        public String ClinicName { get; set; }
        public bool? Is_On_Call { get; set; }
        public string Specialization { get; set; }
        public int DoctorTypeName { get; set; }


        public decimal Price { get; set; }

     

    }

 public class DoctorRequestDTO
        {
        public int DoctorID { get; set; }

        public int EmployeeID { get; set; }

        public string MedicalLicenseNumber { get; set; } = null!;

        public short? YearsOfExperience { get; set; }



        public bool? IsOnCall { get; set; }

        public string Specialization { get; set; } = null!;

        public short DoctorTypeID { get; set; }

        public decimal Price { get; set; }



    }
}

