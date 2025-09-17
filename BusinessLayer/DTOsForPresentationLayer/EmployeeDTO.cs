using BusinessLayer;

namespace ClinicAPI.temp.DTOs___Validations
{
    public class EmployeeRequestDTO
    {


        public int EmployeeID { get; set; }
        public int TypeEmpployeeID_FK { get; set; }
        public string Titel { get; set; }
        public int PersonID_FK { get; set; }
        public string NationalID { get; set; }
        public decimal? Salary { get; set; }

        public EmployeeRequestDTO(int employeeID, int typeEmpployeeID_FK, string titel, int personID_FK, string nationalID, decimal salary)
        {
            EmployeeID = employeeID;
            TypeEmpployeeID_FK = typeEmpployeeID_FK;
            Titel = titel;
            PersonID_FK = personID_FK;
            NationalID = nationalID;
            Salary = salary;
        }
        public EmployeeRequestDTO(Employee employee)
        {
            EmployeeID = employee.EmployeeID;
            TypeEmpployeeID_FK = employee.TypeEmpployeeID_FK;
            Titel = employee.Titel;
            PersonID_FK = employee.PersonID_FK;
            NationalID = employee.NationalID;
            Salary = employee.Salary;
        }




    }

    public class EmployeeResponseDTO
    {


        public int EmployeeID { get; set; }
        public int TypeEmpployeeName { get; set; }
        public string Titel { get; set; }
        public int PersonID_FK { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string NationalID { get; set; }
        public decimal? Salary { get; set; }


    }
}
