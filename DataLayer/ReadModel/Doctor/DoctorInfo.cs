namespace DataLayer.ReadModel.Doctor
{
    public class DoctorInfo
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
    }

}

