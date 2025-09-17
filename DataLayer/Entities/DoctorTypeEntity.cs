namespace DataLayer.Entities
{
    public class DoctorTypeEntity
    {
        public short DoctorTypeID { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }

        public ICollection<DoctorEntity> Doctor { get; set; }
    }
}


