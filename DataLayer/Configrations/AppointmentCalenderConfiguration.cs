using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.ReadModel.Appointment;

namespace DataLayer.Configurations
{
    public class AppointmentCalendarConfiguration
        : IEntityTypeConfiguration<AppointmentCalendar>
    {
        public void Configure(EntityTypeBuilder<AppointmentCalendar> builder)
        {
            builder.HasNoKey();
            builder.ToView(null); // Result from Stored Procedure
        }
    }
}
