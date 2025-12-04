using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DataLayer.Entities;

namespace DataLayer.Configrations
{
    public class ScheduleConfigrations : IEntityTypeConfiguration<ScheduleEntity>
    {
        public void Configure(EntityTypeBuilder<ScheduleEntity> builder)
        {
            builder.HasKey(x => x.ScheduleID);
            builder.Property(x => x.ScheduleID).ValueGeneratedOnAdd();
            builder.Property(x => x.ScheduleDate).HasColumnType("date");
            builder.Property(x => x.ActualStartTime).HasColumnType("time").IsRequired();
            builder.Property(x => x.ActualEndTime).HasColumnType("time").IsRequired();


        }
    }
}
    




