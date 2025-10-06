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
    public class PatientData:IPatientRepository
    {
		private readonly Clinicdbcontext _context;
		public PatientData(Clinicdbcontext context)
		{
			_context = context;
		}
		public  async Task<int> AddPatient(PatientEntity patient)
        {

                _context.Patient.Add(patient);
               await _context.SaveChangesAsync();
                return patient.PatientID;
            
        }

        public  async Task<bool> UpdatePatient(PatientEntity patient)
        {
            
                _context.Patient.Update(patient);
                return await _context.SaveChangesAsync() > 0;
            
        }

        public  async Task<bool> DeletePatient(int patientId)
        {

                var patient = _context.Patient.Find(patientId);
                if (patient == null) return false;
                _context.Patient.Remove(patient);
                return await _context.SaveChangesAsync() > 0;
            
        }

        //public  async Task<PatientEntity> GetPatientById(int patientId)
        //{
           
              
            
        //}

        public  async Task<List<PatientEntity>> GetAllPatient()
        {
            using (_context)
            {
                return await _context.Patient.AsNoTracking().ToListAsync();
            }
        }

        

       

      async  Task<PatientEntity> IPatientRepository.FindPatientUserID(int userid)
        {
            throw new NotImplementedException();
        }

        async Task<PatientEntity> IPatientRepository.FindByPatientID(int Patientid)
        {
            return await _context.Patient.FirstOrDefaultAsync(x => x.PatientID == Patientid);
        }

     async   Task<PatientEntity> IPatientRepository.FindPatientUserName(string patientname)
        {
            throw new NotImplementedException();
        }
    }
}
