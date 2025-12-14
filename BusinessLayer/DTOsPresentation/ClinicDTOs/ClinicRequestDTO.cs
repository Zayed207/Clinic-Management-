namespace BusinessLayer.DTOsPresentation.ClinicDTOs
{
    public partial class ClinicRequestDTO
    {
        

        public string ClinicName { get; set; } = null!;

        public string LocationDescription { get; set; } = null!;

        public TimeOnly Start { get; set; }

        public TimeOnly End { get; set; }

        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;

        public bool Available { get; set; }

        public string? Notes { get; set; }


    }
}
