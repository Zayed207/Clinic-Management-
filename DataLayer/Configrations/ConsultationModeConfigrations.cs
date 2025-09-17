using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DataLayer.Entities;

namespace DataLayer.Configrations
{
    public class ConsultationModeConfigrations : IEntityTypeConfiguration<ConsultationModeEntity>
    {
        public void Configure(EntityTypeBuilder<ConsultationModeEntity> builder)
        {
            builder.HasKey(x => x.ModeID);
            builder.Property(x => x.ModeID).ValueGeneratedOnAdd();
            builder.Property(x => x.Mode_Name).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(x => x.Description).HasColumnType("nvarchar(150)").IsRequired();
            
        }
    }
}


