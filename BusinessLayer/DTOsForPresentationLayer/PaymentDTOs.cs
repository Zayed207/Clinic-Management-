using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class PaymentRequestDTO
    {
        public int PaymentID { get; set; }
        public int AppointmentID_FK { get; set; }
        public int ?FromAccountID { get; set; }
        public int ?ToAccountID { get; set; }
        public short? ProviderID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; }

      

    }

    public class PaymentResponseDTO
    {
        public int PaymentID { get; set; }
        public int AppointmentID_FK { get; set; }
        public int? FromAccountID { get; set; }
        public int? ToAccountID { get; set; }
        public short? ProviderID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; }



    }

    //public class PaymentConfigrations : IEntityTypeConfiguration<PaymentEntity>
    //{
    //    public void Configure(EntityTypeBuilder<PaymentEntity> builder)
    //    {
    //        builder.HasKey(x => x.PaymentID);
    //        builder.Property(x => x.PaymentID).ValueGeneratedOnAdd();
    //        builder.Property(x => x.BloodType).HasColumnType("nvarchar(50)").IsRequired();
    //        builder.Property(x => x.ChronicDiseases).HasColumnType("nvarchar(150)").IsRequired();
    //        builder.Property(x => x.IssueDate).HasColumnType("datetime").IsRequired();
    //        builder.Property(x => x.Notes).HasColumnType("nvarchar(250)").IsRequired();

    //    }

    //}
}
