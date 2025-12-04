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
    public class ClinicData :IClinicRepository
    {

        private readonly Clinicdbcontext _context;
        public ClinicData(Clinicdbcontext context)
        {
            _context = context;
        }
        public  async Task<DataLayerOperationResult<int>> AddClinic(ClinicEntity clinic)
        {
           
                
             
            try

            {
                _context.Clinic.Add(clinic);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<int>.SuccessOperation(clinic.ClinicID);


                return DataLayerOperationResult<int>.Fail("problem in operation"); ;




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/AddClinic ", ex);

                return DataLayerOperationResult<int>.InternalError();

            }

        }

        public  async Task<DataLayerOperationResult<bool>> UpdateClinic(ClinicEntity clinic)
        {

            try

            {

                var exsit= _context.Clinic.Find(clinic);
                if (exsit == null)
                {
                    return DataLayerOperationResult<bool>.Fail("this clinic is not exist");

                }



                _context.Clinic.Update(clinic);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("No appointments avaliable"); 




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/UpdateClinic ", ex);

                return DataLayerOperationResult<bool>.InternalError();

            }
           
                
            
        }

        public  async Task<DataLayerOperationResult<bool>> DeleteClinic(int clinicId)
        {
            try

            {

                var clinic = await _context.Clinic.FindAsync(clinicId);
                if (clinic == null)
                {
                    return DataLayerOperationResult<bool>.Fail("this clinic is not exist");

                }



                _context.Clinic.Remove(clinic);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("the clinic is not remove"); 




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/DeleteClinic ", ex);


                return DataLayerOperationResult<bool>.InternalError();

            }

          
            
        }

        public  async Task<DataLayerOperationResult<ClinicEntity>> GetClinicById(int clinicId)
        {
          
                
            
            try

            {
                var clinic = await _context.Clinic.FirstOrDefaultAsync(x => x.ClinicID == clinicId);
                if (clinic != null)

                    return DataLayerOperationResult<ClinicEntity>.SuccessOperation(clinic);


                return DataLayerOperationResult<ClinicEntity>.Fail("not exist"); 




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/GetClinicById ", ex);

                return DataLayerOperationResult<ClinicEntity>.InternalError();

            }
        }

        public  async Task<DataLayerOperationResult<List<ClinicEntity>>> GetAllClinics()
        {
            
                
            try

            {
                var list = await _context.Clinic.AsNoTracking().ToListAsync();
                if (list == null || list.Count == 0) return DataLayerOperationResult<List<ClinicEntity>>.Fail("No Clinics avaliable"); 



                return DataLayerOperationResult<List<ClinicEntity>>.SuccessOperation(list);

            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/GetAllClinics ", ex);

                return DataLayerOperationResult<List<ClinicEntity>>.InternalError();

            }

        }
//         try

//            {
//                var list = await _context.Clinic.AsNoTracking().ToListAsync();
//                if (list == null || list.Count == 0) return DataLayerOperationResult<List<ClinicEntity>>.Fail("No Clinics avaliable"); 



//                return DataLayerOperationResult<List<ClinicEntity>>.SuccessOperation(list);

//            }

//            catch (Exception ex)
//            {

//                return DataLayerOperationResult<List<ClinicEntity>>.InternalError();

//            }
//try

//            {

//                var exsit = _context.Clinic.Find(clinic);
//                if (exsit == null)
//                {
//                    return DataLayerOperationResult<bool>.Fail("this clinic is not exist");

//                }



//    _context.Clinic.Update(clinic);
//                if (await _context.SaveChangesAsync() > 0)

//                    return DataLayerOperationResult<bool>.SuccessOperation(true);


//                return DataLayerOperationResult<bool>.Fail("No appointments avaliable"); 




//            }

//            catch (Exception ex)
//            {

//                return DataLayerOperationResult<bool>.InternalError();

//            }
    }
}
