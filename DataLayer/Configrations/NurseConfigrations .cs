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
    public class NurseConfigrations : IEntityTypeConfiguration<NurseEntity>
    {
        public int NurseID { get; set; }
        public int Employee_ID_FK { get; set; }
       
        public int ClinicID_FK { get; set; }
        public void Configure(EntityTypeBuilder<NurseEntity> builder)
        {
            builder.HasKey(x=>x.NurseID);
            builder.Property(x=>x.NurseID).ValueGeneratedOnAdd();
           
            // builder.HasOne(x => x.AppointmentType).WithOne(e => e.Appointment).HasForeignKey<AppointmentEntity>(x => x.pa);

         

            builder.HasOne(x => x.EmployeeID)
                   .WithOne(c => c.nurse)
                   .HasForeignKey<NurseEntity>(x => x.Employee_ID_FK);

            builder.HasOne(x => x.ClinicID)
                   .WithMany(p => p.nurses)
                   .HasForeignKey(x => x.ClinicID_FK);

          

        }
    }
}
