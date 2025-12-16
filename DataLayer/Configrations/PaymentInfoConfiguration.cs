using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DataLayer.ReadModel.Payments;

namespace DataLayer.Configrations
{
    public partial class PaymentConfiguration
    {
        public class PaymentInfoConfiguration
    : IEntityTypeConfiguration<PaymentInfo>
        {
            public void Configure(EntityTypeBuilder<PaymentInfo> builder)
            {
                builder.HasNoKey();
                builder.ToView(null); // SP result
            }
        }

    }
}
