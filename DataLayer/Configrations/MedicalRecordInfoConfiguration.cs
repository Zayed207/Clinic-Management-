using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DataLayer.ReadModel.MedicalRecord;

namespace DataLayer.Configrations
{
    public class MedicalRecordInfoConfiguration
    : IEntityTypeConfiguration<MedicalRecordInfo>
{
    public void Configure(EntityTypeBuilder<MedicalRecordInfo> builder)
    {
        builder.HasNoKey();
        builder.ToView(null); // SP result
    }
}

}

