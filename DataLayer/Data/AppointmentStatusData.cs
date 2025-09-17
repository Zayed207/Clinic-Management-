using DataLayer;
using DataLayer.Contract;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
namespace DataLayer.Data
{
    public class AppointmentStatusData:IAppointmentStatusRepository
    {
        private readonly Clinicdbcontext _context;
        public AppointmentStatusData(Clinicdbcontext context)
        {
            _context = context;
        }
        public async Task <int > AddAppointmentStatus(AppointmentStatusEntity status)
        {
          
                _context.AppointmentStatus.Add(status);
                await _context.SaveChangesAsync();
                return status.Status_ID;
            
        }

        public async Task< bool > UpdateAppointmentStatus(AppointmentStatusEntity status)
        {
           
                _context.AppointmentStatus.Update(status);
                return await _context.SaveChangesAsync() > 0;
            
        }

        public async Task< bool > DeleteAppointmentStatus(int statusId)
        {
            
                var status = _context.AppointmentStatus.Find(statusId);
                if (status == null) return false;
                _context.AppointmentStatus.Remove(status);
                return  await _context.SaveChangesAsync() > 0;
            
        }

        public async Task< AppointmentStatusEntity > GetAppointmentById(int statusId)
        {
            
                return await _context.AppointmentStatus.FirstOrDefaultAsync(x => x.Status_ID == statusId);
            
        }

        public async Task< List<AppointmentStatusEntity> > GetAllAppointmentStatuses()
        {
            
                return await _context.AppointmentStatus.AsNoTracking().ToListAsync();
            
        }

        public Task<AppointmentStatusEntity>? GetAppointmentStatusById(int id)
        {
            throw new NotImplementedException();
        }
    }
}