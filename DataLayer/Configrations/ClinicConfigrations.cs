using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Entities
{
    public partial class ClinicEntity
    {
        public class ClinicConfigrations : IEntityTypeConfiguration<ClinicEntity>
        {
            public void Configure(EntityTypeBuilder<ClinicEntity> builder)
            {
                builder.HasKey(x => x.ClinicID);
                builder.Property(x => x.ClinicID).ValueGeneratedOnAdd();
                builder.Property(x => x.LocationDescription).HasColumnType("nvarchar(255)").IsRequired();
                builder.Property(x => x.Start).HasColumnType("time(0)").IsRequired();
                builder.Property(x => x.End).HasColumnType("time(0)").IsRequired();
                builder.Property(x => x.City).HasColumnType("nvarchar(20)").IsRequired();
                builder.Property(x => x.Country).HasColumnType("nvarchar(20)").IsRequired();
                builder.Property(x => x.Available).HasColumnType("bit").IsRequired();
                builder.Property(x => x.Notes).HasColumnType("nvarchar(250)").IsRequired();
            }
        }
    }
}
