using DataLayer.Entities;

namespace DataLayer.Contract
{
    public interface IScheduleRepository
    {
        int AddSchedule(ScheduleEntity entity);
        bool UpdateSchedule(ScheduleEntity entity);
        bool DeleteSchedule(int id);
       
        
    }
}
