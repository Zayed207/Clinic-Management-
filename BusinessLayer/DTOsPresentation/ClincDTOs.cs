using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOsForPresentationLayer
{
    public partial class ClinicRequestDTO
    {
        public int ClinicID { get; set; }

        public string ClinicName { get; set; } = null!;

        public string LocationDescription { get; set; } = null!;

        public TimeOnly Start { get; set; }

        public TimeOnly End { get; set; }

        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;

        public bool Available { get; set; }

        public string? Notes { get; set; }


    }

    public partial class ClinicResponseDTO
    {
        public int ClinicID { get; set; }
        public string ClinicName { get; set; }
        public string LocationDescription { get; set; }

        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }
        public string City { get; set; }

        public List<string> DoctorsNames { get; set; }

        public ClinicResponseDTO(Clinic clinic)
        {
            ClinicID = clinic.ClinicID;
            ClinicName = clinic.ClinicName;
            LocationDescription = clinic.LocationDescription;
            Start = clinic.Start;
            End = clinic.End;
            City = clinic.City;
            DoctorsNames = DoctorsNames;
        }
    }
}
