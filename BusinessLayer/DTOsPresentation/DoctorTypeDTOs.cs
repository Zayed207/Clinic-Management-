namespace BusinessLayer.DTOsPresentation
{
    public class DoctorTypeDTO
    {
        public enum enDoctorType
        {
            GeneralDoctor = 2,
            Specialist  ,
            Consultant  ,
            ResidentDoctor,
            SeniorConsultant
        }

        public short DoctorTypeID { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }


       
    }
}


