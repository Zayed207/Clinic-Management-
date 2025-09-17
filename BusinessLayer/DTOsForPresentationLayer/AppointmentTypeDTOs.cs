using DataLayer.Entities;

public partial class AppointmentTypeDTO
{
    public int Type_ID { get; set; }
    public string Type_Name { get; set; }
    public string Description { get; set; }

  //  public ICollection<DataLayer.Entities.AppointmentDTOs> Appointments { get; set; }
}