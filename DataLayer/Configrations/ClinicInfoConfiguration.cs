using DataLayer.ReadModel.Clinic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configrations
{
    public class ClinicInfoConfiguration
    : IEntityTypeConfiguration<ClinicInfo>
    {
        public void Configure(EntityTypeBuilder<ClinicInfo> builder)
        {
            builder.HasNoKey();
            builder.ToView(null);
        }
    }

}
