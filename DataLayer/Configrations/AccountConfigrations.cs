using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configrations
{
    public class AccountConfigrations : IEntityTypeConfiguration<AccountEntity>
    {
        public void Configure(EntityTypeBuilder<AccountEntity> builder)
        {
            builder.HasKey(x=>x.AccountID);
            builder.Property(x=>x.AccountID).ValueGeneratedOnAdd();
      
            // builder.HasOne(x => x.AppointmentType).WithOne(e => e.Appointment).HasForeignKey<AppointmentEntity>(x => x.pa);

           
            builder.Property(x => x.AccountName).IsRequired();

            builder.HasOne(x => x.PaymentProvider)
                   .WithMany(c => c.accounts)
                   .HasForeignKey(x => x.AccountProviderID_FK);

          

        }
    }
}
