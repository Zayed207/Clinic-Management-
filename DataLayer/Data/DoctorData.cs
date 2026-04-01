using DataLayer.Contract;
using DataLayer.Entities;
using DataLayer.ReadModel.Doctor;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataLayer.Data
{
    public  class DoctorData:IDoctorRepository
    {
        private readonly Clinicdbcontext _context;
        public DoctorData(Clinicdbcontext context)
        {
            _context = context;
        }
        public async Task<DataLayerOperationResult<int>> AddDoctor(DoctorEntity doctor)
        {

           

            try

            {

               



                _context.Doctor.Add(doctor);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return DataLayerOperationResult<int>.SuccessOperation(doctor.DoctorID);
                }
                else

                    return DataLayerOperationResult<int>.Fail("adding not successfuly");




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/AddDoctor ", ex);

                return DataLayerOperationResult<int>.InternalError();

            }

        }

        public  async Task<DataLayerOperationResult<bool>> UpdateDoctor(DoctorEntity doctor)
        {
            try

            {

                var exsit = _context.Doctor.FindAsync(doctor.DoctorID);
                if (exsit == null)
                {
                    return DataLayerOperationResult<bool>.Fail("this doctor is not exist");

                }



                _context.Doctor.Update(doctor);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("updating is not successfuly");




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/AddDoctor ", ex);

                return DataLayerOperationResult<bool>.InternalError();

            }

                
                
                
                
        }

        public  async Task<DataLayerOperationResult<bool>> DeleteDoctorByEmployeeID(int doctorId)
        {
            try

            {

                var exsit =await _context.Doctor.FindAsync(doctorId);
                if (exsit == null)
                {
                    return DataLayerOperationResult<bool>.Fail("this clinic is not exist");

                }



                _context.Doctor.Remove(exsit);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("No appointments avaliable");




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/DeleteDoctorByEmployeeID ", ex);

                return DataLayerOperationResult<bool>.InternalError();

            }
           
            
        }

        public async Task<DataLayerOperationResult<DoctorInfo>> GetDoctorInfoByUserId(int userId)
        {
            try
            {
                var row = await _context.DoctorInfo
                    .FromSqlRaw(
                        "EXEC sp_GetDoctorInfoByUserId @UserId",
                        new SqlParameter("@UserId", userId))
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                if (row == null)
                    return DataLayerOperationResult<DoctorInfo>
                        .NotFound("Doctor not found");

                return DataLayerOperationResult<DoctorInfo>.SuccessOperation(row);
            }
            catch (Exception ex)
            {
                Log.Error(ex,
                    "DB Error in GetDoctorInfoByUserId | UserId: {UserId}",
                    userId);

                return DataLayerOperationResult<DoctorInfo>.InternalError();
            }
        }


        public async Task<DataLayerOperationResult<List<DoctorEntity>>> GetAllDoctors()
        {

            try

            {
                var doctors = await _context.Doctor.AsNoTracking().ToListAsync();
                if (doctors == null || doctors.Count == 0) return DataLayerOperationResult<List<DoctorEntity>>.Fail("No doctors avaliable");



                return DataLayerOperationResult<List<DoctorEntity>>.SuccessOperation(doctors);

            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/GetAllDoctors ", ex);


                return DataLayerOperationResult<List<DoctorEntity>>.InternalError();

            }

           
            
        }
        public Task<DataLayerOperationResult<bool>> IsDoctorExistByEmployeeID(int employeeid)
        {
            throw new NotImplementedException();
        }

     

        public Task<DataLayerOperationResult<DoctorEntity>> GetDoctorByClinicId(int clinicid)
        {
            throw new NotImplementedException();

        }
        public Task<DataLayerOperationResult<List<DoctorEntity>>>GetAllDoctorsInClinc(int clinicid)
        {
            throw new NotImplementedException();
        }

        public Task<DataLayerOperationResult<List<DoctorEntity>>>GetAllDoctorsInClinc(string clinicname)
        {
            throw new NotImplementedException();
        }

        public Task<DataLayerOperationResult<DoctorEntity>> GetDoctorByEmployeeID(int employeeid)
        {
            throw new NotImplementedException();

        }




















        //

    }
}
