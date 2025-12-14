namespace DataLayer.ReadModel.Clinic
{
   
        public class ClinicInfo
        {
            public int ClinicId { get; set; }

            public string ClinicName { get; set; } = string.Empty;

            public string LocationDescription { get; set; } = string.Empty;

            public TimeOnly StartTime { get; set; }

            public TimeOnly EndTime { get; set; }

            public string Country { get; set; } = string.Empty;

            public string City { get; set; } = string.Empty;

            public bool IsAvailable { get; set; }

            public string? Notes { get; set; }
        }

    

}
