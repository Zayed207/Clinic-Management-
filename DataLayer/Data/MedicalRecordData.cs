using DataLayer.Contract;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;
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
		public  async Task<DataLayerOperationResult<int>> AddMedicalRecord(MedicalRecordEntity record)
        {
           
          
            try
            {





                _context.MedicalRecord.Add(record);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<int>.SuccessOperation(record.MRID);


                return DataLayerOperationResult<int>.Fail("adding not successfuly");




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/AddMedicalRecord ", ex);

                return DataLayerOperationResult<int>.InternalError();

            }
        }

        public  async Task<DataLayerOperationResult<bool>> UpdateMedicalRecord(MedicalRecordEntity record)
        {
            
               
               ;
            try

            {

                var exsit = await _context.Employees.FindAsync(record.MRID);
                if (exsit == null)
                {
                    return DataLayerOperationResult<bool>.Fail("this employee is not exist");

                }



                _context.MedicalRecord.Update(record);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("woring!!");




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/UpdateMedicalRecord ", ex);


                return DataLayerOperationResult<bool>.InternalError();

            }
        }

        public  async Task<DataLayerOperationResult<bool>> DeleteMedicalRecord(int recordId)
        {

               
               
            try

            {

                var record =await _context.MedicalRecord.FindAsync(recordId);
                if (record == null)
                {
                    return DataLayerOperationResult<bool>.Fail("this mdecalrecordid dosen't exist");

                }



                _context.MedicalRecord.Remove(record);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("deleting is not successfuly");




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/DeleteMedicalRecord ", ex);


                return DataLayerOperationResult<bool>.InternalError();

            }
        }

        public  async Task<DataLayerOperationResult<MedicalRecordEntity>> GetMedicalRecordById(int recordId)
        {
            try

            {

                var record = await _context.MedicalRecord.FirstOrDefaultAsync(x=>x.MRID==recordId);
                if (record == null)
                {
                    return DataLayerOperationResult<MedicalRecordEntity>.Fail("this mdecalrecordid dosen't exist");

                }



               

                    return DataLayerOperationResult<MedicalRecordEntity>.SuccessOperation(record);


              




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/GetMedicalRecordById ", ex);


                return DataLayerOperationResult<MedicalRecordEntity>.InternalError();

            }

        }

        public  async Task<DataLayerOperationResult<List<MedicalRecordEntity>>> GetAllMedicalRecordOfPatient(int patientid)
        {
           
                
            try

            {
                var medicalRecords = await _context.MedicalRecord.AsNoTracking().ToListAsync();
                if (medicalRecords == null || medicalRecords.Count == 0) return DataLayerOperationResult<List<MedicalRecordEntity>>.Fail("No employees avaliable");



                return DataLayerOperationResult<List<MedicalRecordEntity>>.SuccessOperation(medicalRecords);

            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/GetAllMedicalRecordOfPatient ", ex);

                return DataLayerOperationResult<List<MedicalRecordEntity>>.InternalError();

            }


        }

       

        Task<DataLayerOperationResult<List<MedicalRecordEntity>>> IMedicalRecordRepository.GetMedicalRecordsForPatientByUserID(int userId)
        {
            throw new NotImplementedException();
        }

        Task<DataLayerOperationResult<MedicalRecordEntity>> IMedicalRecordRepository.GetLastMedcalRecordForPatientByUserId(int mrnId)
        {
            throw new NotImplementedException();
        }
    }
}
