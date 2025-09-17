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
    public  class DoctorData:IDoctorRepository
    {
        private readonly Clinicdbcontext _context;
        public DoctorData(Clinicdbcontext context)
        {
            _context = context;
        }
        public async Task<int> AddDoctor(DoctorEntity doctor)
        {

           

                _context.Doctor.Add(doctor);
              await  _context.SaveChangesAsync();


                return doctor.DoctorID;

            
        }

        public  async Task<bool> UpdateDoctor(DoctorEntity doctor)
        {
            
               
                    _context.Doctor.Update(doctor);
                    return await _context.SaveChangesAsync() > 0;
                  
                
                
                
                
        }

        public  async Task<bool> DeleteDoctor(int doctorId)
        {
            
                var doctor = _context.Doctor.Find(doctorId);
                if (doctor == null) return false;
                _context.Doctor.Remove(doctor);
                return await _context.SaveChangesAsync() > 0;
            
        }

        public  async Task<DoctorEntity> GetDoctorById(int doctorID)
        {
            
                return await _context.Doctor.FirstOrDefaultAsync(x => x.DoctorID == doctorID);
            
        }

        public  async Task<List<DoctorEntity>> GetAllDoctors()
        {
          


                List<DoctorEntity> doctors = await _context.Doctor.AsNoTracking().ToListAsync();


                return doctors;
            
        }


        Task<bool> IDoctorRepository.IsDoctorExist(int employeeid)
        {
            throw new NotImplementedException();
        }

        Task<DoctorEntity> IDoctorRepository.GetDoctorByUserId(int employeeId)
        {
            throw new NotImplementedException();
        }

        Task<DoctorEntity> IDoctorRepository.GetDoctorByClinicId(int employeeId)
        {
            throw new NotImplementedException();
        }

        Task<List<DoctorEntity>> IDoctorRepository.GetAllDoctorsInClinc(int clinicid)
        {
            throw new NotImplementedException();
        }

        Task<List<DoctorEntity>> IDoctorRepository.GetAllDoctorsInClinc(string clinicname)
        {
            throw new NotImplementedException();
        }
    }
}
