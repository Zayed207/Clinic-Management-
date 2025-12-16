using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DataLayer.Entities;

namespace DataLayer.Configrations
{
    public class MedicalRecordConfigrations : IEntityTypeConfiguration<MedicalRecordEntity>
    {
        public void Configure(EntityTypeBuilder<MedicalRecordEntity> builder)
        {
            builder.HasKey(x => x.MRID);
            builder.Property(x => x.MRID).ValueGeneratedOnAdd();
            builder.Property(x => x.BloodType).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(x => x. ChronicDiseases).HasColumnType("nvarchar(150)").IsRequired();
            builder.Property(x => x.IssueDate).HasColumnType("date").IsRequired();
            builder.Property(x => x.Notes).HasColumnType("nvarchar(250)").IsRequired();
            
        }
       

    }

}

