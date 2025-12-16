using DataLayer.ReadModel.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configrations.EmpolyeeConfigration
{
    public class EmployeeInfoConfiguration
    : IEntityTypeConfiguration<EmployeeInfo>
    {
        public void Configure(EntityTypeBuilder<EmployeeInfo> builder)
        {
            builder.HasNoKey();
            builder.ToView(null); 
        }
    }
}
