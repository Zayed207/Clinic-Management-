using DataLayer.Data;
using DataLayer.Entities;

namespace DataLayer.Contract
{
    public interface IScheduleRepository
    {
        public  Task<DataLayerOperationResult<int>> AddScheduleAsync(ScheduleEntity schedule);
        public Task<DataLayerOperationResult<bool>> UpdateSchedule(ScheduleEntity schedule);

        public  Task<DataLayerOperationResult<bool>> DeleteSchedule(int scheduleId);


    }
}
