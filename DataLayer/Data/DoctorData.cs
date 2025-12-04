using DataLayer.Contract;
using DataLayer.Entities;
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

                    return DataLayerOperationResult<int>.SuccessOperation(doctor.DoctorID);


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

        public  async Task <DataLayerOperationResult<DoctorEntity>> GetDoctorById(int doctorID)
        {
            try

            {

                var exsit = await _context.Doctor.SingleOrDefaultAsync(x=>x.DoctorID==doctorID);
                if (exsit != null)
                {
                   
                    return DataLayerOperationResult<DoctorEntity>.SuccessOperation(exsit);
                }

                 return DataLayerOperationResult<DoctorEntity>.Fail("this clinic is not exist");


                    


            




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/GetDoctorById ", ex);

                return DataLayerOperationResult<DoctorEntity>.InternalError();

            }

           
            
        }

        public  async Task<DataLayerOperationResult<List<DoctorEntity>>> GetAllDoctors()
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

        public DataLayerOperationResult<Task<DoctorEntity>> GetDoctorByUserId(int employeeId)
        {
            throw new NotImplementedException();
        }

        public DataLayerOperationResult<Task<DoctorEntity>> GetDoctorByClinicId(int clinicid)
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

        Task<DataLayerOperationResult<DoctorEntity>> IDoctorRepository.GetDoctorByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        Task<DataLayerOperationResult<DoctorEntity>> IDoctorRepository.GetDoctorByClinicId(int clinicId)
        {
            throw new NotImplementedException();
        }


        //public async Task<List<DoctorEntity>> GetAllPatientByDoctorID(int doctorid)
        //{

        //    var data =await(from a in _context.Appointment
        //               join p in _context.Patient on a.Patient_ID_FK equals p.PatientID
        //               join at in _context.AppointmentType on a.AppointmentTypeID_FK equals at.Type_ID
        //               join per in _context.Person on p.PatientPersonID_FK equals per.PersonID
        //               join mr in _context.MedicalRecord on p.PatientID equals mr.PatientID_FK
        //                     where a.Doctor_ID_FK == doctorid
        //                     select new
        //               {
        //                         p.PatientID,
        //                   FullName= per.FirstName+""+ per.LastName,

        //                   per.Gender,
        //                   per.Age,
        //                   a.Appointment_Date_Time,
        //                   at.Type_Name,
        //                   mr.BloodType,
        //                   mr.ChronicDiseases,
        //                   mr.Notes




        //               }).AsNoTracking().ToListAsync();


        //                        var grouped = data
        //                .GroupBy(x => new { x.PatientID, x.FullName, x.Gender, x.Age, x.Type_Name, x.Appointment_Date_Time })
        //                .Select(g => new PatientSummary
        //                {
        //                    PatientID = g.Key.PatientID,
        //                    FullName = g.Key.FullName,
        //                    Gender = g.Key.Gender,
        //                    Age = g.Key.Age,
        //                    LastAppointmentDate = g.Key.Appointment_Date_Time,
        //                    AppointmentTypeName = g.Key.Type_Name,
        //                    MedicalRecords = g.Select(r => new MedicalRecordSummary
        //                                       {
        //                                            BloodType = r.BloodType,
        //                                            ChronicDiseases = r.ChronicDiseases,
        //                                            Notes = r.Notes
        //                                                                 }).ToList()
        //                                                                     }).ToList();


        //}





        //public async Task<List<Tuple<string,int>>> GetTopDoctorsAppointment( short number ,DateOnly date1, DateOnly date2)
        //{

        //    var result = await _context.Doctor.FromSql($"SELECT TOP {number} \r\n    d.DoctorID,\r\n    COUNT(a.Appointment_ID) AS AppointmentCount,a.Appointment_Date_Time\r\nFROM Doctor d\r\nINNER JOIN Appointment a ON d.DoctorID = a.Doctor_ID_FK\r\nwhere a.Appointment_Date_Time between {date1}and {date1}\r\nGROUP BY d.DoctorID,a.Appointment_Date_Time\r\nORDER BY AppointmentCount DESC;").AsNoTracking().ToListAsync();




        //    List<DoctorEntity> doctors = await _context.Doctor.AsNoTracking().ToListAsync();
        //    return doctors;
        //}














        //

    }
}
