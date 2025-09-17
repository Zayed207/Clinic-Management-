using DataLayer.Contract;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public  class NurseData:INurseRepository
    {
		private readonly Clinicdbcontext _context;
		public NurseData(Clinicdbcontext context)
		{
			_context = context;
		}
		public  async Task<int> AddNurse(NurseEntity nurse)
        {
            
                _context.Nurse.Add(nurse);
            await    _context.SaveChangesAsync();
                return nurse.NurseID;
            
        }

        public  async Task<bool> UpdateNurse(NurseEntity nurse)
        {
            
                _context.Nurse.Update(nurse);
                return await _context.SaveChangesAsync() > 0;
            
        }

        public  async Task<bool> DeleteNurse(int nurseId)
        {
            
                var nurse = _context.Nurse.Find(nurseId);
                if (nurse == null) return false;
                _context.Nurse.Remove(nurse);
                return await _context.SaveChangesAsync() > 0;
            
        }

        public  async Task<NurseEntity> GetNurseById(int nurseId)
        {
            
                return await _context.Nurse.FirstOrDefaultAsync(x => x.NurseID == nurseId);
            
        }

        public  async Task<List<NurseEntity>> GetAllNurse()
        {
            
                return await _context.Nurse.AsNoTracking().ToListAsync();
            
        }
    }
}
