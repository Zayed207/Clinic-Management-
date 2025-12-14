using DataLayer.ReadModel.Doctor;

namespace BusinessLayer.DTOsPresentation.DoctorDTO
{
    public class DoctorInfoDTO
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string MedicalLicenseNumber { get; set; } = string.Empty;
        public int? YearsOfExperience { get; set; }

        public string ClinicName { get; set; } = string.Empty;

        public bool? IsOnCall { get; set; }

        public string Specialization { get; set; } = string.Empty;
        public string DoctorType { get; set; } = string.Empty;

        public decimal Price { get; set; }
        public DoctorInfoDTO(DoctorInfo r)
        {
            EmployeeId = r.EmployeeId;
            FullName = r.FullName;
            UserName = r.UserName;
            Title = r.Title;
            MedicalLicenseNumber = r.MedicalLicenseNumber;
            YearsOfExperience = r.YearsOfExperience;
            ClinicName = r.ClinicName;
            IsOnCall = r.IsOnCall;
            Specialization = r.Specialization;
            DoctorType = r.DoctorType;
            Price = r.Price;
        }

        // static converter (أسلوبك الموحد)
        public static DoctorInfoDTO FromDoctorInfo(DoctorInfo r)
            => new DoctorInfoDTO(r);
    }

}

