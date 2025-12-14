using DataLayer.Contract;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Serilog;
using Microsoft.Data.SqlClient;
using DataLayer.ReadModel.Appointment;
namespace DataLayer.Data
{
    public class AppointmentData : IAppointmentRepository
    {
        private readonly Clinicdbcontext _context;
        public AppointmentData(Clinicdbcontext context)
        {
            _context = context;
        }
        public async Task<DataLayerOperationResult<bool>> IsAppointmentAvailable(DateTime date)
        {
            try
            {
                var newStart = date;
                var newEnd = date.AddMinutes(60);

                var iss= await _context.Appointment.AnyAsync(a =>
                    a.AppointmentDateTime < newEnd &&
                    newStart < a.AppointmentDateTime.AddMinutes(a.AppointmentDurationMinutes)
                );
                if (!iss)
                {
                    return DataLayerOperationResult<bool>.SuccessOperation(iss);
                }
                return DataLayerOperationResult<bool>.Fail();
            }
            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/IsAppointmentAvailable ", ex);
                return DataLayerOperationResult<bool>.InternalError();


            }
        }

        public async Task<DataLayerOperationResult<int>> AddNewAppointment(AppointmentEntity appointment)
        {

            
            

            try

            {
                _context.Appointment.Add(appointment);
                if (await _context.SaveChangesAsync()>0)
                {
                    return DataLayerOperationResult<int>.SuccessOperation(appointment.Appointment_ID);
                }
                else return DataLayerOperationResult<int>.Fail();
            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/AddAppointment ", ex);

                return DataLayerOperationResult<int>.InternalError();

            }

        }

        public async Task<DataLayerOperationResult<bool>> UpdateAppointment(AppointmentEntity appointment)
        {
            try

            {
                _context.Appointment.Update(appointment);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return DataLayerOperationResult<bool>.SuccessOperation(true);
                }
                else return DataLayerOperationResult<bool>.Fail();
            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/UpdateAppointment ", ex);

                return DataLayerOperationResult<bool>.InternalError();

            }
        }

        public async Task<DataLayerOperationResult<bool>> DeleteAppointment(int appointmentId)
        {

            
            try

            {
                var appointment = _context.Appointment.Find(appointmentId);
                if (appointment == null) return DataLayerOperationResult<bool>.Fail("the appointmentId dosen't exsit"); ;
                _context.Appointment.Remove(appointment);

                ;
                if (await _context.SaveChangesAsync() > 0)
                {
                    return DataLayerOperationResult<bool>.SuccessOperation(true);
                }
                else return DataLayerOperationResult<bool>.Fail();
            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/DeleteAppointment ", ex);

                return DataLayerOperationResult<bool>.InternalError();

            }

        }

        public async Task<DataLayerOperationResult<bool>> DeleteAppointmentByPatientID(int patientId)
        {

            try

            {
                var appointment = _context.Appointment.Find(patientId);
                if (appointment == null) return DataLayerOperationResult<bool>.Fail("the appointmentId dosen't exsit"); ;
                _context.Appointment.Remove(appointment);

                ;
                if (await _context.SaveChangesAsync() > 0)
                {
                    return DataLayerOperationResult<bool>.SuccessOperation(true);
                }
                else return DataLayerOperationResult<bool>.Fail();
            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/DeleteAppointmentByPatientID ", ex);

                return DataLayerOperationResult<bool>.InternalError();

            }

        }

        public async Task<DataLayerOperationResult<List<AppointmentEntity>>> GetAllAppointment()
        {
            
            
            try

            {
                var list = await _context.Appointment.AsNoTracking().ToListAsync();
                if (list ==null || list.Count == 0) return DataLayerOperationResult<List<AppointmentEntity>>.Fail("No appointments avaliable") ;
               

               
                    return DataLayerOperationResult<List<AppointmentEntity>>.SuccessOperation(list);
               
            }

            catch (Exception ex)
            {

                
                Log.Error("DataBase Exception in  DataLayer/GetAllAppointment ",ex);
                return DataLayerOperationResult<List<AppointmentEntity>>.InternalError();

            }

        }

        public async Task<DataLayerOperationResult<List<AppointmentEntity>>> GetAllAppointmentsToDay()
        {
            var today = DateOnly.FromDateTime(DateTime.Now);

          


            try

            {
                var appointmentstoday = await _context.Appointment
                            .Where(x => DateOnly.FromDateTime(x.AppointmentDateTime) == today)
                            .AsNoTracking()
                            .ToListAsync();
                if (appointmentstoday == null || appointmentstoday.Count == 0) return DataLayerOperationResult<List<AppointmentEntity>>.Fail("No appointments avaliable today"); ;



                return DataLayerOperationResult<List<AppointmentEntity>>.SuccessOperation(appointmentstoday);

            }

            catch (Exception ex)
            {

                return DataLayerOperationResult<List<AppointmentEntity>>.InternalError();

            }
        }



        public async Task<DataLayerOperationResult<List<AppointmentCalendar>>> GetAllAppointmentsToDayByDoctorID(int DoctorID)
        {
            try {

                var appointmentstoday = await GetDoctorAppointmentsByDate(DoctorID,DateTime.Now.Date);
            if (appointmentstoday.Data == null || appointmentstoday.Data.Count==0) return DataLayerOperationResult<List<AppointmentCalendar>>.Fail("No appointments avaliable today"); ;



            return DataLayerOperationResult<List<AppointmentCalendar>>.SuccessOperation(appointmentstoday.Data);

        }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/GetAllAppointmentsToDayByDoctorID ", ex);

                return DataLayerOperationResult<List<AppointmentCalendar>>.InternalError();

            }

}

       
        public async Task<DataLayerOperationResult<List<AppointmentsDetails>>> GetAllAppointmentsToDayByClinicName(string clinicname)
        {
        try
        {

            var appointmentstoday = await (
                from a in _context.Appointment
                join p in _context.Patient on a.PatientID_FK equals p.PatientID
                join per in _context.Person on p.PatientPersonID_FK equals per.PersonID
                join at in _context.AppointmentType on a.AppointmentTypeID_FK equals at.TypeID
                join ats in _context.AppointmentStatus on a.StatusID_FK equals ats.StatusID
                join mr in _context.MedicalRecord on p.PatientID equals mr.PatientID_FK
                join c in _context.Clinic on a.ClinicID_FK equals c.ClinicID
                where c.ClinicName == clinicname
                select new AppointmentsDetails
                {
                    FirstName = per.FirstName,
                    LastName = per.LastName,
                    Phone = per.Phone,
                    Age = per.Age,
                    BloodType = mr.BloodType,
                    ChronicDiseases = mr.ChronicDiseases,
                    IssueDate = mr.IssueDate,
                    AppointmentHour = a.AppointmentDateTime,
                    AppointmentTypeName = at.TypeName,
                    AppointmentStatusName = ats.StatusName,
                    Notes = a.Notes
                }
                    )
                    .AsNoTracking()
                    .ToListAsync();
                if (appointmentstoday == null || appointmentstoday.Count == 0) return DataLayerOperationResult<List<AppointmentsDetails>>.Fail("No appointments avaliable today"); ;



            return DataLayerOperationResult< List < AppointmentsDetails >>.SuccessOperation(appointmentstoday);

        }

        catch (Exception ex)
        {

                Log.Error("DataBase Exception in  DataLayer/GetAllAppointmentsToDayByDoctorID ", ex);


                return DataLayerOperationResult<List<AppointmentsDetails>>.InternalError();

        }

    }

        public async Task<DataLayerOperationResult<AppointmentEntity>> GetAppointmentByID(int id)
        {
            try

            {
                var AT = await _context.Appointment.Where(x => x.Appointment_ID == id).FirstOrDefaultAsync();
                if (AT != null)

                    return DataLayerOperationResult<AppointmentEntity>.SuccessOperation(AT);


                return DataLayerOperationResult<AppointmentEntity>.Fail("not exist"); ;




            }

            catch (Exception ex)
            {
                Log.Error("DataBase Exception in  DataLayer/GetAppointmentById ", ex);

                return DataLayerOperationResult<AppointmentEntity>.InternalError();

            }
        }

        async Task<DataLayerOperationResult<List<AppointmentCalendar>>> GetDoctorAppointmentsByDate(int doctorId, DateTime date)
        {
            try
            {
                var result = await _context.AppointmentCalendar
              .FromSqlRaw(
              "EXEC dbo.GetAppointmentsForDoctorByDate @DoctorID, @Date",
              new SqlParameter("@DoctorID", doctorId),
              new SqlParameter("@Date", date)
                 )
                 .AsNoTracking()
                 .ToListAsync();

                if (result == null || result.Count == 0)
                    return DataLayerOperationResult<List<AppointmentCalendar>>
                        .NotFound("No appointments found for this doctor and date.");

                return DataLayerOperationResult<List<AppointmentCalendar>>
                    .SuccessOperation(result);
            }
            catch (Exception ex)

            {
                Log.Error("DataBase Exception in  DataLayer/GetAllAppointmentsToDayByDoctorID ", ex);

                return DataLayerOperationResult<List<AppointmentCalendar>>.InternalError();
            }
        }        
    }

}


