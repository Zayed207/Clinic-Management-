using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Entities
{
    public partial class PaymentProviderEntity
    {
        public class PaymentProviderConfigrations : IEntityTypeConfiguration<PaymentProviderEntity>
        {
            public void Configure(EntityTypeBuilder<PaymentProviderEntity> builder)
            {
                builder.HasKey(x => x.ProviderID);
                builder.Property(x => x.ProviderID).ValueGeneratedOnAdd();
                builder.Property(x => x.ProviderName).HasColumnType("nvarchar(50)").IsRequired();
                builder.Property(x => x.ProviderType).HasColumnType("nvarchar(150)").IsRequired();
                
                builder.Property(x => x.Description).HasColumnType("nvarchar(250)").IsRequired();

            }

        }
    }
}
