using DataLayer;
using DataLayer.Contract;
using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class ConsultationModeData:IConsultationModeRepository
    {
        private readonly Clinicdbcontext _context;
        public ConsultationModeData(Clinicdbcontext context)
        {
            _context = context;
        }
        public  int AddConsultationMode(ConsultationModeEntity mode)
        {
            using (_context)
            {
                _context.ConsultationModes.Add(mode);
                _context.SaveChanges();
                return mode.ModeID;
            }
        }

        public  bool UpdateConsultationMode(ConsultationModeEntity mode)
        {
            using (_context)
            {
                _context.ConsultationModes.Update(mode);
                return _context.SaveChanges() > 0;
            }
        }

        public  bool DeleteConsultationMode(int modeId)
        {
            using (_context)
            {
                var mode = _context.ConsultationModes.Find(modeId);
                if (mode == null) return false;
                _context.ConsultationModes.Remove(mode);
                return _context.SaveChanges() > 0;
            }
        }

        public  ConsultationModeEntity GetConsultationModeById(int modeId)
        {
            using (_context)
            {
                return _context.ConsultationModes.FirstOrDefault(x => x.ModeID == modeId);
            }
        }

        public  List<ConsultationModeEntity> GetAllConsultationMode()
        {
            using (_context)
            {
                return _context.ConsultationModes.AsNoTracking().ToList();
            }
        }

    }

}


