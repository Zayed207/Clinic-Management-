using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public partial class EmployeeTypeEntity {

        public  short EmployeeTypeID{ get; set; }
        public string TypeName{ get; set; }
        public ICollection<EmployeeEntity> Employees { get; set; }
    }
}
