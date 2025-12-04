using DataLayer.Contract;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Numerics;

namespace DataLayer.Data
{
    public class DoctorTypeData:IDoctorTypeRepository
    {

        private readonly Clinicdbcontext _context;
        public DoctorTypeData(Clinicdbcontext context)
        {
            _context = context;
        }
    
        public async Task<DataLayerOperationResult<int> >AddDoctorType(DoctorTypeEntity entity)
        {
            try
            {





                _context.DoctorTypes.Add(entity);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<int>.SuccessOperation(entity.DoctorTypeID);


                return DataLayerOperationResult<int>.Fail("Adding is not successfuly");




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/AddDoctorType ", ex);

                return DataLayerOperationResult<int>.InternalError();

            }

        }

        public async Task<DataLayerOperationResult<bool> >DeleteDoctorType(int id)
        {
            try

            {

                var exsit =await _context.DoctorTypes.FindAsync(id);
                if (exsit == null)
                {
                    return DataLayerOperationResult<bool>.Fail("this doctor is not exist");

                }



                _context.DoctorTypes.Remove(exsit);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("deleting is not successfuly");




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/DeleteDoctorType ", ex);

                return DataLayerOperationResult<bool>.InternalError();

            }
        }

        public async Task<DataLayerOperationResult<List<DoctorTypeEntity>>> GetAllDoctorTypes()
        {
            try

            {
                var doctors = await _context.DoctorTypes.AsNoTracking().ToListAsync();
                if (doctors == null || doctors.Count == 0) return DataLayerOperationResult<List<DoctorTypeEntity>>.Fail("No doctors avaliable");



                return DataLayerOperationResult<List<DoctorTypeEntity>>.SuccessOperation(doctors);

            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/GetAllDoctorTypes ", ex);


                return DataLayerOperationResult<List<DoctorTypeEntity>>.InternalError();

            }
        }

        public async Task<DataLayerOperationResult<DoctorTypeEntity>> GetDoctorTypeById(int id)
        {
            try

            {

                var exsit = await _context.DoctorTypes.SingleOrDefaultAsync(x=>x.DoctorTypeID ==id);
                if (exsit != null)
                {

                    return DataLayerOperationResult<DoctorTypeEntity>.SuccessOperation(exsit);
                }

                return DataLayerOperationResult<DoctorTypeEntity>.Fail("this clinic is not exist");










            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/GetDoctorTypeById ", ex);

                return DataLayerOperationResult<DoctorTypeEntity>.InternalError();

            }
        }



        public async Task<DataLayerOperationResult< bool >>UpdateDoctorType(DoctorTypeEntity entity)
        {
            try

            {

                var exsit = await _context.DoctorTypes.FindAsync(entity.DoctorTypeID);
                if (exsit == null)
                {
                    return DataLayerOperationResult<bool>.Fail("this clinic is not exist");

                }



                _context.DoctorTypes.Update(entity);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("woring!!");




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/UpdateDoctorType ", ex);


                return DataLayerOperationResult<bool>.InternalError();

            }
        }
    }

}


