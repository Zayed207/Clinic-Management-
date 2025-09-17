using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public partial class EmployeeTypeEntity {

        public  short EmployeeTypeID{ get; set; }
        public string TypeName{ get; set; }
        public ICollection<EmployeeEntity> Employees { get; set; }
    }
}
