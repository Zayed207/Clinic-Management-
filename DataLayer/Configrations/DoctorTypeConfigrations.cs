using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DataLayer.Entities;

namespace DataLayer.Configrations
{
    public class DoctorTypeConfigrations : IEntityTypeConfiguration<DoctorTypeEntity>
    {
        public void Configure(EntityTypeBuilder<DoctorTypeEntity> builder)
        {
            builder.HasKey(x => x.DoctorTypeID);
            builder.Property(x => x.DoctorTypeID).ValueGeneratedOnAdd();
            builder.Property(x => x.TypeName).HasColumnType("nvarchar(150)").IsRequired();
            builder.Property(x => x.Description).HasColumnType("nvarchar(150)").IsRequired();

        }
    }
}


