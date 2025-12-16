using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ReadModel.Employee
{
    public class EmployeeInfo
    {

        public int EmployeeID { get; set; }
        public string TypeEmpployeeName { get; set; } = string.Empty;
        public string Titel { get; set; } = string.Empty;

        public int PersonID_FK { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string NationalID { get; set; } = string.Empty;

        public decimal? Salary { get; set; }
        public int UserID { get; set; }
    }
}
