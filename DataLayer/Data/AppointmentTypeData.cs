using DataLayer;
using DataLayer.Contract;
using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Threading.Tasks;

public class AppointmentTypeData:IAppointmentTypeRepository
{
    private readonly Clinicdbcontext _context;
    public AppointmentTypeData(Clinicdbcontext context)
    {
        _context = context;
    }
    public  async Task<DataLayerOperationResult<int>> AddAppointmentType(AppointmentTypeEntity status)
    {
      
            
    
        try

        {
           _context.AppointmentType.Add(status) ;
            if (await _context.SaveChangesAsync()>0)

                return DataLayerOperationResult<int>.SuccessOperation(status.TypeID);


            return DataLayerOperationResult<int>.Fail("problem in operation"); ;




        }

        catch (Exception ex)
        {
            Log.Error("DataBase Exception in  DataLayer/AddAppointmentType ", ex);


            return DataLayerOperationResult<int>.InternalError();

        }

    }




    public  async Task<DataLayerOperationResult< bool>> UpdateAppointmentType(AppointmentTypeEntity appointmentType)
    {
        
            
            


    try

    {

        var exist = _context.AppointmentType.Find(appointmentType);
        if (exist == null)
        {
            return DataLayerOperationResult<bool>.Fail("appointmentyper is not exist"); ;

        }



        var id = _context.AppointmentType.Update(appointmentType);
        if (await _context.SaveChangesAsync() > 0)

            return DataLayerOperationResult<bool>.SuccessOperation(true);


        return DataLayerOperationResult<bool>.Fail(" something worng during updating"); ;




    }

    catch (Exception ex)

        { 
    Log.Error("DataBase Exception in  DataLayer/UpdateAppointmentType ", ex);
        

            return DataLayerOperationResult<bool>.InternalError();

    }

}

    public  async Task<DataLayerOperationResult<bool>> DeleteAppointmentType(int appointmenttypeid)
    {
        
           
            
            
            

        try

        {

            var exist = _context.AppointmentType.Find(appointmenttypeid);
            if (exist == null)
            {
                return DataLayerOperationResult<bool>.Fail("appointmentyper is not exist"); ;

            }



            _context.AppointmentType.Remove(exist);
            if (await _context.SaveChangesAsync() > 0)

                return DataLayerOperationResult<bool>.SuccessOperation(true);


            return DataLayerOperationResult<bool>.Fail(" something worng during deleting"); ;




        }

        catch (Exception ex)
        {
            Log.Error("DataBase Exception in  DataLayer/DeleteAppointmentType ", ex);

            return DataLayerOperationResult<bool>.InternalError();

        }
    }

  
    

    public async Task<DataLayerOperationResult<AppointmentTypeEntity>> GetAppointmentTypeById(int id)
    {

        try

        {
            var AT = await _context.AppointmentType.Where(x => x.TypeID == id).SingleOrDefaultAsync() ;
            if (AT != null)

                return DataLayerOperationResult<AppointmentTypeEntity>.SuccessOperation(AT);


            return DataLayerOperationResult<AppointmentTypeEntity>.Fail("not exist"); ;




        }

        catch (Exception ex)
        {
            Log.Error("DataBase Exception in  DataLayer/GetAppointmentTypeById ", ex);

            return DataLayerOperationResult<AppointmentTypeEntity>.InternalError();

        }
        
    }

    public  async Task<DataLayerOperationResult<List<AppointmentTypeEntity>>> GetAllAppointmentTypes()
    {
       
        try

        {
            var list = await _context.AppointmentType.ToListAsync();
            if (list == null || list.Count == 0) return DataLayerOperationResult<List<AppointmentTypeEntity>>.Fail("No AppointmentTypesavaliable"); ;



            return DataLayerOperationResult<List<AppointmentTypeEntity>>.SuccessOperation(list);

        }

        catch (Exception ex)
        {
            Log.Error("DataBase Exception in  DataLayer/GetAllAppointmentTypes ", ex);

            return DataLayerOperationResult<List<AppointmentTypeEntity>>.InternalError();

        }
    }

   
}