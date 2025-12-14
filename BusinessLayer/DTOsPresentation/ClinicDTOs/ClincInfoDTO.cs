using DataLayer.Entities;
using DataLayer.ReadModel.Clinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOsPresentation.ClinicDTOs
{

    public class ClinicInfoDTO
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

    
        public ClinicInfoDTO(ClinicInfo row)
        {
            ClinicId = row.ClinicId;
            ClinicName = row.ClinicName;
            LocationDescription = row.LocationDescription;
            StartTime = row.StartTime;
            EndTime = row.EndTime;
            Country = row.Country;
            City = row.City;
            IsAvailable = row.IsAvailable;
            Notes = row.Notes;
        }
        public ClinicInfoDTO(ClinicEntity row)
        {
            ClinicId = row.ClinicID;
            ClinicName = row.ClinicName;
            LocationDescription = row.LocationDescription;
            StartTime = row.Start;
            EndTime = row.End;
            Country = row.Country;
            City = row.City;
            IsAvailable = row.Available;
            Notes = row.Notes;
        }


        public static ClinicInfoDTO FromClinicInfoDTO(ClinicInfo row)
        {
            return new ClinicInfoDTO(row);
        }
        public static List<ClinicInfoDTO> ClinicEntityListToClinicInfo(List<ClinicEntity> clinicEntities)
        {
            var clinics = new List<ClinicInfoDTO>();

            foreach (var entity in clinicEntities)
            {
                clinics.Add(new ClinicInfoDTO(entity));

            }
            return clinics;
        }
    }

   
}
