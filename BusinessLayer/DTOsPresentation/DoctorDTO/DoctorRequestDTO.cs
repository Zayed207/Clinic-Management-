using static BusinessLayer.DTOsPresentation.DoctorTypeDTO;

namespace BusinessLayer.DTOsPresentation.DoctorDTO
{
    public class DoctorRequestDTO
        {
       

        public int EmployeeID { get; set; }

        public string MedicalLicenseNumber { get; set; } = null!;

        public short? YearsOfExperience { get; set; }



        public bool? IsOnCall { get; set; }

        public string Specialization { get; set; } = null!;

        public enDoctorType DoctorTypeID { get; set; }

        public decimal Price { get; set; }



    }
}

