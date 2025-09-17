using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class PersonEntity
    {

        public int PersonID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; } 
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Country { get; set; } 

        public short? Age { get; set; } 
        public int?  UserID_FK {  get; set; }
        public UserEntity user { get; set; }
        public EmployeeEntity Employee { get; set; }

        public PatientEntity patient{ get; set; }
    }
}
