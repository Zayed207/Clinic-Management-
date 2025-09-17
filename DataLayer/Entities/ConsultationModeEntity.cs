namespace DataLayer.Entities
{
    public class ConsultationModeEntity
    {
        public int ModeID { get; set; }
        public string Mode_Name { get; set; }
        public string Description { get; set; }


        public ICollection<AppointmentEntity> Appointmentsnt { get; set; }
    }
}


