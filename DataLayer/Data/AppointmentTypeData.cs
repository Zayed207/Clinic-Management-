using DataLayer;
using DataLayer.Contract;
using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

public class AppointmentTypeData:IAppointmentTypeRepository
{
    private readonly Clinicdbcontext _context;
    public AppointmentTypeData(Clinicdbcontext context)
    {
        _context = context;
    }
    public  int AddAppointmentType(AppointmentTypeEntity status)
    {
        using (_context)
        {
            _context.AppointmentType.Add(status);
            _context.SaveChanges();
            return status.Type_ID;
        }
    }

    public  bool UpdateAppointmentType(AppointmentTypeEntity status)
    {
        using (_context)
        {
            _context.AppointmentType.Update(status);
            return _context.SaveChanges() > 0;
        }
    }

    public  bool DeleteAppointmentType(int statusId)
    {
        using (_context)
        {
            var status = _context.AppointmentType.Find(statusId);
            if (status == null) return false;
            _context.AppointmentType.Remove(status);
            return _context.SaveChanges() > 0;
        }
    }

    public  AppointmentTypeEntity GetTypeById(int statusId)
    {
        using (_context )
        {
            return _context.AppointmentType.FirstOrDefault(x => x.Type_ID == statusId);
        }
    }

    public  List<AppointmentTypeEntity> GetAllStatuses()
    {
        using (_context)
        {
            return _context.AppointmentType.AsNoTracking().ToList();
        }
    }

    public AppointmentTypeEntity GetAppointmentTypeById(int id)
    {
        throw new NotImplementedException();
    }

    public List<AppointmentTypeEntity> GetAllAppointmentTypes()
    {
        throw new NotImplementedException();
    }
}