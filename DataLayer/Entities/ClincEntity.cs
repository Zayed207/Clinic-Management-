using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public partial class ClinicEntity
    {
        public int ClinicID { get; set; }
        public string ClinicName { get; set; }
        public string LocationDescription { get; set; }
       
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string City { get; set; }

        public ICollection<AppointmentEntity> Appointments { get; set; }
        public ICollection<DoctorEntity> doctors{ get; set; }

        public ICollection<NurseEntity> nurses { get; set; }
    }
}
