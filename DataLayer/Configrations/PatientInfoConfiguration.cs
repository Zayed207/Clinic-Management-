using DataLayer.ReadModel.Patient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configrations
{
    public partial class PatientConfigrations
    {
        public class PatientInfoConfiguration
    : IEntityTypeConfiguration<PatientInfo>
        {
            public void Configure(EntityTypeBuilder<PatientInfo> builder)
            {
                builder.HasNoKey();
                builder.ToView(null); // SP result
            }
        }

    }
}
