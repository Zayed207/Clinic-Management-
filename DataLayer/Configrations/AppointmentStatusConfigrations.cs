using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AppointmentStatusConfigrations : IEntityTypeConfiguration<AppointmentStatusEntity>
{
    public void Configure(EntityTypeBuilder<AppointmentStatusEntity> builder)
    {
        builder.HasKey(x => x.StatusID);
        builder.Property(x => x.StatusID).ValueGeneratedOnAdd();
        builder.Property(x => x.StatusName).IsRequired();
        builder.Property(x => x.Description).HasColumnType("nvarchar(100)");
    }
}