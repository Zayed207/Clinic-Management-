using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class PatientEntity
    {
        public int PatientID { get; set; }

        public int PatientPersonID { get; set; }

        public string ?EmergencyContactName { get; set; }

        public string? EmergencyContactPhone { get; set; }


        public DateTime RegisterDatew { get; set; }

        public ICollection<AppointmentEntity> Appointments { get; set; }
        public PersonEntity Person { get; set; }
        public ICollection<MedicalRecordEntity> medicalRecords{ get; set; }
    }
}
