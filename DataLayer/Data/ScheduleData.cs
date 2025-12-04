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
		public  async Task<DataLayerOperationResult<int>> AddScheduleAsync(ScheduleEntity schedule)
        {
           
             
               
                try
                {





                    _context.Schedule.Add(schedule);
                    if (await _context.SaveChangesAsync() > 0)

                        return DataLayerOperationResult<int>.SuccessOperation(schedule.ScheduleID);


                    return DataLayerOperationResult<int>.Fail("adding not successfuly");




                }

                catch (Exception ex)
                {

                    return DataLayerOperationResult<int>.InternalError();

                }
            }

        public async Task<DataLayerOperationResult<bool>> UpdateSchedule(ScheduleEntity schedule)
        {
         
            try

            {

                var exsit = await _context.Schedule.FindAsync(schedule.ScheduleID);
                if (exsit == null)
                {
                    return DataLayerOperationResult<bool>.Fail("this schedule is not exist");

                }



                _context.Schedule.Update(schedule);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("woring!!");




            }

            catch (Exception ex)
            {

                return DataLayerOperationResult<bool>.InternalError();

            }
        }

        public async Task<DataLayerOperationResult<bool>> DeleteSchedule(int scheduleId)
        {
        
            
            try

            {

                var schedule =await _context.Schedule.FindAsync(scheduleId);
                if (schedule == null)
                {
                    return DataLayerOperationResult<bool>.Fail("this schedule is not exist");

                }



                _context.Schedule.Remove(schedule);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("deleting is not successfuly");




            }

            catch (Exception ex)
            {

                return DataLayerOperationResult<bool>.InternalError();

            }
        }

        //public  ScheduleEntity GetScheduleByEmployeeId(int employeeid)
        //{
        //    //using (_context )
        //    //{
        //    //    return _context.Schedule.FirstOrDefault(x => x.DoctorID_FK == employeeid);
        //    //}
        //}

        //public async Task<DataLayerOperationResult<List<ScheduleEntity>>> GetAllSchedule()
        //{
        //    using (_context)
        //    {
        //        return _context.Schedule.AsNoTracking().ToList();
        //    }
        //}

    }
}