using DataLayer.Contract;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class AppointmentData: IAppointmentRepository
    {
        private readonly Clinicdbcontext _context;
        public AppointmentData(Clinicdbcontext context)
        {
            _context = context;
        }
        public async Task<bool> IsAppointmentUnavailable(DateTime date)
        {

        return await  _context.Appointment.AnyAsync(c => c.Appointment_Date_Time >= date &&
    c.Appointment_Date_Time <= date.AddMinutes(60));

        }

        public  async Task<int> AddAppointment(AppointmentEntity appointment)
        {
            
                _context.Appointment.Add(appointment);
               await _context.SaveChangesAsync();
                return  appointment.Appointment_ID;
            
        }

        public  async Task<bool> UpdateAppointment(AppointmentEntity appointment)
        {
           
                _context.Appointment.Update(appointment);
                return await _context.SaveChangesAsync() > 0;
            
        }

        public  async Task<bool> DeleteAppointment(int appointmentId)
        {
            
                var appointment = _context.Appointment.Find(appointmentId);
                if (appointment == null) return false;
                _context.Appointment.Remove(appointment);
                return await _context.SaveChangesAsync() > 0;
            
        }

        public async Task< bool >DeleteAppointmentByPatientID(int patientId)
        {
            
                var appointment = _context.Appointment.Find(patientId);
                if (appointment == null) return false;
                _context.Appointment.Remove(appointment);
                return await _context.SaveChangesAsync() > 0;
            
        }

        public  async Task<List<AppointmentEntity>> GetAllAppointment()
        {
              return await _context.Appointment.ToListAsync();
            
        }

        public async Task< List<AppointmentEntity> >GetAllAppointmentsToDay()
        {
            
                return await _context.Appointment.Where(x=>x.Appointment_Date_Time==DateTime.Now). AsNoTracking().ToListAsync();
            
        }


        public async Task< List<AppointmentEntity> >GetAllAppointmentsToDayByDoctorID(int DoctorID)
        {
            
                return await _context.Appointment.Where(x => x.Doctor_ID_FK== DoctorID).AsNoTracking().ToListAsync();
            
        }

        public async Task <List<AppointmentEntity> >GetAllAppointmentsToDayByClinicName(string clinicname)
        {
           
                return await _context.Appointment.Where(x => x.Clinic.ClinicName== clinicname).AsNoTracking().ToListAsync();
            
        }
    }

}


