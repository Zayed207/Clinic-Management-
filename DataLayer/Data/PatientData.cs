using DataLayer.Contract;
using DataLayer.Entities;
using DataLayer.ReadModel.Patient;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;
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
		public  async Task<DataLayerOperationResult<int>> AddPatient(PatientEntity patient)
        {

           
            try
            {





                _context.Patient.Add(patient);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<int>.SuccessOperation(patient.PatientID);


                return DataLayerOperationResult<int>.Fail("adding not successfuly");




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/AddPatient ", ex);

                return DataLayerOperationResult<int>.InternalError();

            }
        }

        public  async Task<DataLayerOperationResult<bool>> UpdatePatient(PatientEntity patient)
        {
            
               
                
            try

            {

                var exsit = await _context.Employees.FindAsync(patient.PatientID);
                if (exsit == null)
                {
                    return DataLayerOperationResult<bool>.Fail("this employee is not exist");

                }



                _context.Patient.Update(patient);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("woring!!");




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/UpdatePatient ", ex);

                return DataLayerOperationResult<bool>.InternalError();

            }
        }

        public  async Task<DataLayerOperationResult<bool>> DeletePatient(int patientId)
        {

                
               
                
              
            try

            {

                var patient =await _context.Patient.FindAsync(patientId);
                if (patient == null)
                {
                    return DataLayerOperationResult<bool>.Fail("this doctor is not exist");

                }



                _context.Patient.Remove(patient);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("deleting is not successfuly");




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/DeletePatient ", ex);

                return DataLayerOperationResult<bool>.InternalError();

            }
        }

    

        public  async Task<DataLayerOperationResult<List<PatientEntity>>> GetAllPatient()
        {
            
                

            try

            {
                var patients = await _context.Patient.AsNoTracking().ToListAsync();
                if (patients == null || patients.Count == 0) return DataLayerOperationResult<List<PatientEntity>>.Fail("No employees avaliable");



                return DataLayerOperationResult<List<PatientEntity>>.SuccessOperation(patients);

            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/GetAllPatient ", ex);

                return DataLayerOperationResult<List<PatientEntity>>.InternalError();

            }

        }






        public async Task<DataLayerOperationResult<PatientInfo>>GetPatientInfoByUserID(int userId)
        {
            try
            {
                var data = await _context.PatientInfo
                    .FromSqlRaw(
                        "EXEC sp_GetPatientInfoByUserId @UserID",
                        new SqlParameter("@UserID", userId))
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                if (data == null)
                    return DataLayerOperationResult<PatientInfo>
                        .NotFound("Patient not found");

                return DataLayerOperationResult<PatientInfo>
                    .SuccessOperation(data);
            }
            catch (Exception ex)
            {
                Log.Error(ex,
                    "DB Error in GetPatientInfoByUserId | UserID: {UserID}",
                    userId);

                return DataLayerOperationResult<PatientInfo>
                    .InternalError();
            }
        }

    }
}
