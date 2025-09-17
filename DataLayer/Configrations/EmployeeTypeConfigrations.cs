using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Entities
{
    public partial class EmployeeTypeEntity {
        public class EmployeeTypeConfigrations : IEntityTypeConfiguration<EmployeeTypeEntity>
        {
            public void Configure(EntityTypeBuilder<EmployeeTypeEntity> builder)
            {
                builder.HasKey(x => x.EmployeeTypeID);
                builder.Property(x => x.EmployeeTypeID).ValueGeneratedOnAdd();
                builder.Property(x => x.TypeName).HasColumnType("nvarchar(50)").IsRequired();
                

            }
        }
    }
}
