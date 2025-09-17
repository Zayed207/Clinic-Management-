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
    public class MedicalRecordData:IMedicalRecordRepository
    {

		private readonly Clinicdbcontext _context;
		public MedicalRecordData(Clinicdbcontext context)
		{
			_context = context;
		}
		public  async Task<int> AddMedicalRecord(MedicalRecordEntity record)
        {
           
                _context.MedicalRecord.Add(record);
           await     _context.SaveChangesAsync();
                return record.MRNID;
            
        }

        public  async Task<bool> UpdateMedicalRecord(MedicalRecordEntity record)
        {
            
                _context.MedicalRecord.Update(record);
                return await _context.SaveChangesAsync() > 0;
            
        }

        public  async Task<bool> DeleteMedicalRecord(int recordId)
        {

                var record = _context.MedicalRecord.Find(recordId);
                if (record == null) return false;
                _context.MedicalRecord.Remove(record);
                return await _context.SaveChangesAsync() > 0;
            
        }

        public  async Task<MedicalRecordEntity> GetMedicalRecordById(int recordId)
        {
            
                return await _context.MedicalRecord.FirstOrDefaultAsync(x => x.MRNID == recordId);
            
        }

        public  async Task<List<MedicalRecordEntity>> GetAllMedicalRecord()
        {
           
                return await _context.MedicalRecord.AsNoTracking().ToListAsync();
            
        }

        public Task<List<MedicalRecordEntity>> GetMedicalRecordsForPatientByUserID(int userid)
        {
            throw new NotImplementedException();
        }

        public Task<MedicalRecordEntity> GetLastMedcalRecordForPatientByuserId(int mrnId)
        {
            throw new NotImplementedException();
        }
    }
}
