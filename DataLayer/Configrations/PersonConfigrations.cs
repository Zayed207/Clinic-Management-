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
    public class PersonConfigrations : IEntityTypeConfiguration<PersonEntity>
    {
    

      
        public void Configure(EntityTypeBuilder<PersonEntity> builder)
        {
            builder.HasKey(x=>x.PersonID);
            builder.Property(x=>x.PersonID).ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName). HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(x => x.LastName).HasColumnType("nvarchar(50)").IsRequired();

            builder.Property(x => x.DateOfBirth).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Phone).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(x => x.Address).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(x => x.Country).HasColumnType("nvarchar(50)").IsRequired();
            

             builder.HasOne(x => x.user).WithOne(e => e.Person).HasForeignKey<PersonEntity>(x => x.UserID_FK);

           

           

        }
    }
}
