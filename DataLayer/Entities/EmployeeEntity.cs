using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public  class  EmployeeEntity
    {
        public int EmployeeID { get; set; }
        public short EmpployeeTypeID_FK { get; set; }
        public EmployeeTypeEntity EmployeeType { get; set; }

        public string Title { get; set; }
        public int PersonID_FK { get; set; }
        public PersonEntity person { get; set; }


        //public int UserID_FK { get; set; }
        //public UserEntity User { get; set; }

        public string NationalID { get; set; }
        public decimal ?Salary { get; set; }


        public  DoctorEntity doctor { get; set; }

        public NurseEntity nurse { get; set; }


        public ScheduleEntity schedule { get; set; }


    }

    public class EmployeeConfigration : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
           builder.HasKey(e => e.EmployeeID);
            builder.Property(e => e.EmployeeID).ValueGeneratedOnAdd();


       //     builder.HasOne(e => e.EmployeeType)                 
       //.WithMany(t => t.Employees)                    
       //.HasForeignKey<EmployeeEntity>(e => e.TypeEmpployeeID_FK);


            builder.HasOne(p => p.person).WithOne(e => e.Employee).HasForeignKey<EmployeeEntity>(e => e.PersonID_FK);



        }
    }
}
