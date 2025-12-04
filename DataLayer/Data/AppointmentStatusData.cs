using DataLayer;
using DataLayer.Contract;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;
namespace DataLayer.Data
{
    public class AppointmentStatusData:IAppointmentStatusRepository
    {
        private readonly Clinicdbcontext _context;
        public AppointmentStatusData(Clinicdbcontext context)
        {
            _context = context;
        }
        public async Task <DataLayerOperationResult< int >> AddAppointmentStatus(AppointmentStatusEntity status)
        {
          
               
                
                
            try

            {
                var id = await _context.AppointmentStatus.AddAsync(status);
                if( await  _context.SaveChangesAsync()>0)

                    return DataLayerOperationResult<int>.SuccessOperation(status.StatusID);


                return DataLayerOperationResult<int>.Fail("No appointments avaliable"); ;




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/AddAppointmentStatus ", ex);


                return DataLayerOperationResult<int>.InternalError();

            }

        }

        public async Task<DataLayerOperationResult<bool >> UpdateAppointmentStatus(AppointmentStatusEntity status)
        {
           
                
                

            try

            {
                
                var exist = _context.AppointmentStatus.Find(status);
                if( exist == null )
                {
                    return DataLayerOperationResult<bool>.Fail("No appointments avaliable"); ;

                }



                var id =  _context.AppointmentStatus.Update(status); ;
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("No appointments avaliable"); ;




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/UpdateAppointmentStatus ", ex);

                return DataLayerOperationResult<bool>.InternalError();

            }

        }

        public async Task<DataLayerOperationResult<bool >> DeleteAppointmentStatus(int statusId)
        {
            
               
                
              
            try

            {

                var status = _context.AppointmentStatus.Find(statusId);
                if (status == null)
                {
                    return DataLayerOperationResult<bool>.Fail("this statusId is not exist");

                }



                _context.AppointmentStatus.Remove(status);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("No appointments avaliable"); ;




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/DeleteAppointmentStatus ", ex);

                return DataLayerOperationResult<bool>.InternalError();

            }

        }

        public async Task<DataLayerOperationResult<AppointmentStatusEntity >> GetAppointmentStatusById(int statusId)
        {
            
               
            try

            {
                var id = await _context.AppointmentStatus.AsNoTracking().FirstOrDefaultAsync(x => x.StatusID == statusId); ;
                if (id!=null)

                    return DataLayerOperationResult<AppointmentStatusEntity>.SuccessOperation(id);


                return DataLayerOperationResult<AppointmentStatusEntity>.Fail("not exist"); ;




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/GetAppointmentStatusById ", ex);


                return DataLayerOperationResult<AppointmentStatusEntity>.InternalError();

            }

        }

        public async Task<DataLayerOperationResult< List<AppointmentStatusEntity>> > GetAllAppointmentStatuses()
        {
            
              
            try

            {
                var list = await _context.AppointmentStatus.AsNoTracking().ToListAsync();
                if (list == null || list.Count == 0) return DataLayerOperationResult<List<AppointmentStatusEntity>>.Fail("No AppointmentStatuses avaliable"); ;



                return DataLayerOperationResult<List<AppointmentStatusEntity>>.SuccessOperation(list);

            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/GetAllAppointmentStatuses ", ex);


                return DataLayerOperationResult<List<AppointmentStatusEntity>>.InternalError();

            }

        }

      
    }
}