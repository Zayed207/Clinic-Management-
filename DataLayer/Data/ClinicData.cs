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
    public class ClinicData :IClinicRepository
    {

        private readonly Clinicdbcontext _context;
        public ClinicData(Clinicdbcontext context)
        {
            _context = context;
        }
        public  async Task<int> AddClinic(ClinicEntity clinic)
        {
           
                _context.Clinic.Add(clinic);
               await _context.SaveChangesAsync();
                return clinic.ClinicID;
            
        }

        public  async Task<bool> UpdateClinic(ClinicEntity clinic)
        {
            
                _context.Clinic.Update(clinic);
                return await _context.SaveChangesAsync() > 0;
            
        }

        public  async Task<bool> DeleteClinic(int clinicId)
        {
          
                var clinic = await _context.Clinic.FindAsync(clinicId);
                if (clinic == null) return false;
                _context.Clinic.Remove(clinic);
                return _context.SaveChanges() > 0;
            
        }

        public  async Task<ClinicEntity> GetClinicById(int clinicId)
        {
            using (_context )
            {
                return await _context.Clinic.FirstOrDefaultAsync(x => x.ClinicID == clinicId);
            }
        }

        public  async Task<List<ClinicEntity>> GetAllClinics()
        {
            
                return await _context.Clinic.AsNoTracking().ToListAsync();
            
        }


    }
}
