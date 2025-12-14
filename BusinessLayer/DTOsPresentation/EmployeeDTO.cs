using BusinessLayer;

namespace BusinessLayer.DTOsPresentation
{
    public class EmployeeRequestDTO
    {


        public int EmployeeID { get; set; }

        public short EmpployeeTypeID { get; set; }

        public int ClinicID { get; set; }
        public string Title { get; set; } = null!;

        public int PersonID { get; set; }

        public string NationalID { get; set; } = null!;

        public int UserID { get; set; }


        public EmployeeRequestDTO(Employee Entity)
        {
            EmployeeID = Entity.EmployeeID;
            EmpployeeTypeID = Entity.EmpployeeTypeID;
            ClinicID = Entity.ClinicID;
            Title = Entity.Title;
            PersonID = Entity.PersonID;
            NationalID = Entity.NationalID;

            UserID = Entity.UserID;
        }




    }

    public class EmployeeResponseDTO
    {


        public int EmployeeID { get; set; }
        public string TypeEmpployeeName { get; set; }
        public string Titel { get; set; }
        public int PersonID_FK { get; set; }
        public string FullName { get; set; }
        public string NationalID { get; set; }
        public decimal? Salary { get; set; }


    }
}
