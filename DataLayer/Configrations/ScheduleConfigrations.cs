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
            builder.Property(x => x.ScheduleDate).HasColumnType("datetime");
            builder.Property(x => x.ActualStartTime).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.ActualEndTime).HasColumnType("datetime").IsRequired();
            builder.HasOne(x => x.Employee).WithOne(x => x.schedule).HasForeignKey<ScheduleEntity>(x => x.EmployeeID_FK);
        }
    }

}


