using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public  class NurseEntity
    {
        public short NurseID { get; set; }
        public int Employee_ID_FK { get; set; }
        public EmployeeEntity EmployeeID { get; set; }
        public int ClinicID_FK { get; set; }
        public ClinicEntity ClinicID { get; set; }

        
    }

}
