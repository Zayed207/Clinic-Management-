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
        public string ClinicName { get; set; }
        public string LocationDescription { get; set; }
       
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string City { get; set; }

       
    }

    public partial class ClinicResponseDTO
    {
        public int ClinicID { get; set; }
        public string ClinicName { get; set; }
        public string LocationDescription { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string City { get; set; }

        public List<string> DoctorsNames { get; set; }

        public ClinicResponseDTO(Clinic clinic, List<string> doctorsnames)
        {
            ClinicID = clinic.ClinicID;
            ClinicName = clinic.ClinicName;
            LocationDescription = clinic.LocationDescription;
            Start = clinic.Start;
            End = clinic.End;
            City = clinic.City;
            DoctorsNames = doctorsnames;
        }
    }
}
