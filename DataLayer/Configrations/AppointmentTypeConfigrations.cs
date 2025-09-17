using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public partial class AppointmentTypeEntity
{
    public class AppointmentTypeConfigrations : IEntityTypeConfiguration<AppointmentTypeEntity>
    {
        public void Configure(EntityTypeBuilder<AppointmentTypeEntity> builder)
        {
            builder.HasKey(x => x.Type_ID);
            builder.Property(x => x.Type_ID).ValueGeneratedOnAdd();
            builder.Property(x => x.Type_Name).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.Description).HasColumnType("nvarchar(100)");
        }
    }
}