using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class DoctorEntity
    {

        public int DoctorID{ get; set; }
        public int Employee_ID_FK { get; set; }
        public EmployeeEntity Employee { get; set; }

        public string MedicalLicenseNumber { get; set; }
        public short ?Years_of_Experience { get; set; }
        
        public int ClinicID_FK { get; set; }
        public ClinicEntity Clinic { get; set; }

        public bool? Is_On_Call { get; set; }
        public string Specialization { get; set; }
        
        public short DoctorTypeID_FK { get; set; }
        public DoctorTypeEntity doctorType { get; set; }

        public decimal Price { get; set; }

        public ICollection<AppointmentEntity> Appointments{ get; set; }

        

        

    }

}


