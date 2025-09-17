using DataLayer.Contract;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Data
{
    public class ScheduleData:IScheduleRepository

    {
		private readonly Clinicdbcontext _context;
		public ScheduleData(Clinicdbcontext context)
		{
			_context = context;
		}
		public  int AddSchedule(ScheduleEntity schedule)
        {
            using (_context)
            {
                _context.Schedule.Add(schedule);
                _context.SaveChanges();
                return schedule.ScheduleID;
            }
        }

        public  bool UpdateSchedule(ScheduleEntity schedule)
        {
            using (_context)
            {
                _context.Schedule.Update(schedule);
                return _context.SaveChanges() > 0;
            }
        }

        public  bool DeleteSchedule(int scheduleId)
        {
            using (_context)
            {
                var schedule = _context.Schedule.Find(scheduleId);
                if (schedule == null) return false;
                _context.Schedule.Remove(schedule);
                return _context.SaveChanges() > 0;
            }
        }

        public  ScheduleEntity GetScheduleByEmployeeId(int employeeid)
        {
            using (_context )
            {
                return _context.Schedule.FirstOrDefault(x => x.EmployeeID_FK == employeeid);
            }
        }

        public  List<ScheduleEntity> GetAllSchedule()
        {
            using (_context)
            {
                return _context.Schedule.AsNoTracking().ToList();
            }
        }

    }
}