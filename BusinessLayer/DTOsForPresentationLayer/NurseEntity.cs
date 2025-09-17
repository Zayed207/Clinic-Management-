using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class NurseRequestDTO
    {
        public short NurseID { get; set; }
        public int Employee_ID_FK { get; set; }

        public int ClinicID_FK { get; set; }



    }

    public class NurseResponseDTO
    {
        public short NurseID { get; set; }
        public int EmployeeID_FK { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ClinicID_FK { get; set; }
        public string ClinicName
        {
            get; set;


        }

    }
}
