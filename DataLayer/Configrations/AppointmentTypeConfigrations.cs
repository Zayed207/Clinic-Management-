using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DataLayer.Entities;

public partial class AppointmentType
{
    public class AppointmentTypeConfigrations : IEntityTypeConfiguration<AppointmentTypeEntity>
    {
        public void Configure(EntityTypeBuilder<AppointmentTypeEntity> builder)
        {
            builder.HasKey(x => x.TypeID);
            builder.Property(x => x.TypeID).ValueGeneratedOnAdd();
            builder.Property(x => x.TypeName).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.Description).HasColumnType("nvarchar(100)");
        }
    }
}