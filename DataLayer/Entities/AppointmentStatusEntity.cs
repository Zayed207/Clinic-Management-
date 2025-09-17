using DataLayer.Entities;

public class AppointmentStatusEntity
{
    public int Status_ID { get; set; }
    public string Status_Name { get; set; }
    public string Description { get; set; }

    public ICollection<AppointmentEntity> Appointments { get; set; }




}
