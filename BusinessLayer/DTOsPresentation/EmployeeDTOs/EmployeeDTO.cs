using BusinessLayer;
using DataLayer.ReadModel.Employee;

namespace BusinessLayer.DTOsPresentation
{
    public class EmployeeRequestDTO
    {


       

        public short EmpployeeTypeID { get; set; }

        public int ClinicID { get; set; }
        public string Title { get; set; } = null!;

        public int PersonID { get; set; }

        public string NationalID { get; set; } = null!;

        public int UserID { get; set; }


        public EmployeeRequestDTO(Employee Entity)
        {
          
            EmpployeeTypeID = Entity.EmpployeeTypeID;
            ClinicID = Entity.ClinicID;
            Title = Entity.Title;
            PersonID = Entity.PersonID;
            NationalID = Entity.NationalID;

            UserID = Entity.UserID;
        }




    }
    public class EmployeeInfoDTO
    {
        public int EmployeeID { get; set; }
        public string TypeEmpployeeName { get; set; } = string.Empty;
        public string Titel { get; set; } = string.Empty;

        public int PersonID_FK { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string NationalID { get; set; } = string.Empty;

        public decimal? Salary { get; set; }
        public int UserID { get; set; }

        // constructor mapping
        public EmployeeInfoDTO(EmployeeInfo data)
        {
            EmployeeID = data.EmployeeID;
            TypeEmpployeeName = data.TypeEmpployeeName;
            Titel = data.Titel;
            PersonID_FK = data.PersonID_FK;
            FullName = data.FullName;
            NationalID = data.NationalID;
            Salary = data.Salary;
            UserID = data.UserID;
        }

        // static converter (الأسلوب الموحد)
        public static EmployeeInfoDTO FromData(EmployeeInfo data)
            => new EmployeeInfoDTO(data);
    }

}
