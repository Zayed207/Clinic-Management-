using DataLayer.Entities;

public partial class AppointmentTypeEntity
{
    public int Type_ID { get; set; }
    public string Type_Name { get; set; }
    public string Description { get; set; }

    public ICollection<AppointmentEntity> Appointments { get; set; }
}