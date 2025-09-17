using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AppointmentStatusConfigrations : IEntityTypeConfiguration<AppointmentStatusEntity>
{
    public void Configure(EntityTypeBuilder<AppointmentStatusEntity> builder)
    {
        builder.HasKey(x => x.Status_ID);
        builder.Property(x => x.Status_ID).ValueGeneratedOnAdd();
        builder.Property(x => x.Status_Name).IsRequired();
        builder.Property(x => x.Description).HasColumnType("nvarchar(100)");
    }
}