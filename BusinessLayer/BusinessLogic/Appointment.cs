using AutoMapper;
using BusinessLayer.BusinessLogic;
using DataLayer.Contract;
using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using static AppointmentStatus;
using static AppointmentType;
using static BusinessLayer.ConsultationMode;
using BusinessLayer.Validations;
using BusinessLayer.DTOsPresentation.AppoinntmentsDTOs;

namespace BusinessLayer
{
    public  class Appointment
    {
        //private delegate void AppointmentHandler(AppointmentStatus status);
        public enum enAppointmentStatus { Compelete = 1, Cancelled = 2, Pending = 3, NoShow = 4 }
        public enum enAppointmentType
        {
            RegularCheckup = 1,
            FollowUp = 2,
            Emergency = 3,
            InitialConsultation = 4,
            Onlline = 5,

        }
        public enum enConsultationType
        {
            General = 1,
            Specialist = 2,
            SecondOpinion = 3,
            Preventive = 4,
            Diagnostic = 5,
            PostTreatment = 6,
            Counseling = 7
        }
        public int AppointmentID { get; set; }
        public int PatientID{ get; set; }
        public int DoctorID{ get; set; }
        public int ClinicID{ get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public int? AppointmentDurationMinutes { get; set; }
        public short StatusID{ get; set; }
        public   short    AppointmentTypeID{ get; set; }
        public  short   ConsultationModeID{ get; set; }

        public string? Notes { get; set; }

        public Appointment(AppointmentRequestDTO appointment)
        {
            
            PatientID= appointment.PatientID;
            DoctorID= appointment.DoctorID;
            ClinicID= appointment.ClinicID;
            AppointmentDateTime = appointment.AppointmentDateTime;
            AppointmentDurationMinutes = appointment.AppointmentDurationMinutes;
            StatusID= (short)appointment.StatusID;
            AppointmentTypeID= (short)appointment.AppointmentTypeID;
            ConsultationModeID= (short)appointment.ConsultationModeID;
            Notes = appointment
                .Notes;
          
        }
        public Appointment(AppointmentEntity appointment)
        {
            AppointmentID = appointment.Appointment_ID;
            PatientID= appointment.PatientID_FK;
            DoctorID= appointment.DoctorID_FK;
            ClinicID= appointment.ClinicID_FK;
            AppointmentDateTime = appointment.AppointmentDateTime;
            AppointmentDurationMinutes = appointment.AppointmentDurationMinutes;
            StatusID= (short)enAppointmentStatus.Pending;
            AppointmentTypeID= (short)appointment.AppointmentTypeID_FK;
            ConsultationModeID= (short)appointment.ConsultationModeID_FK;
            Notes = appointment
                .Notes;
            
        }
    }


    public class AppointmentServices
    {

        private readonly IAppointmentRepository _repo;
        private readonly IMapper _mapper;

        public AppointmentServices(IAppointmentRepository Repo, IMapper mapper)
        {
            _repo = Repo;
            _mapper = mapper;
        }

        

        public async Task <OperationResult<int>> CreateAppointment(AppointmentRequestDTO appointment)
        {
            var check = Appoinment_V.CreateAppointmentCheckObject(appointment);
            if (check.Status==ResultStatus.ValidationError)
                return OperationResult<int>.ValidationError($"{check.Message}");



            var result = await _repo.IsAppointmentAvailable(appointment.AppointmentDateTime);
            if (result.ResultType==DataLayerResult.Conflict)
            { return OperationResult<int>.NotFound("The Appointment is Unavalible"); }


            var newappointment = new Appointment(appointment);


            //create the Appointment
            var id = await _repo.AddNewAppointment(_mapper.Map<AppointmentEntity>(newappointment));
            switch (id.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<int>.Success(id.Data, "Appointment deleted successfully.");

                case DataLayerResult.Conflict:
                    return OperationResult<int>.NotFound("Appointment not found or nothing to delete.");

                default:
                    return OperationResult<int>.InternalError($"Unexpected error: {id.Message}");
            }

        }

        public async Task< OperationResult<bool> >UpdateAppointment(AppointmentRequestDTO appointment)
        {
            var check = Appoinment_V.CreateAppointmentCheckObject(appointment);
            if (check.Status == ResultStatus.ValidationError)
                return OperationResult<bool>.ValidationError($"{check.Message}");

             var result=await _repo.IsAppointmentAvailable(appointment.AppointmentDateTime);

            if (result.ResultType==DataLayerResult.Conflict)  return OperationResult<bool>.NotFound("The Appoinment is Unavalible"); 
          
                var updated = await _repo.UpdateAppointment(_mapper.Map<AppointmentEntity>(new Appointment(appointment)));

            switch (updated.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<bool>.Updated("Appointment updated successfully.");

                case DataLayerResult.Conflict:
                    return OperationResult<bool>.NotFound("Appointment not found or nothing to update.");

                default:
                    return OperationResult<bool>.InternalError($"Unexpected error: {updated.Message}");
            }

        
            
        }

        public async Task< OperationResult<bool> >DeleteAppointment(int id)
        {
            if (id > 0)
            {
   
                    return OperationResult<bool>.ValidationError($"id not valid");
            }
            var deleted = await _repo.DeleteAppointment(id);
            switch (deleted.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<bool>.Success(true, "Appointment deleted successfully.");

                case DataLayerResult.Conflict:
                    return OperationResult<bool>.NotFound("Appointment not found or nothing to delete.");

                default:
                    return OperationResult<bool>.InternalError($"Unexpected error: {deleted.Message}");
            }
           
        }

        public async Task<OperationResult<bool> >DeleteAppointmentByPatientID(int patientId)
        {
            
                var deleted =await _repo.DeleteAppointmentByPatientID(patientId);
            switch (deleted.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<bool>.Success(true, "Appointment deleted successfully by patient ID.");

                case DataLayerResult.Conflict:
                    return OperationResult<bool>.NotFound("No appointment found for the given patient ID.");

                default:
                    return OperationResult<bool>.InternalError($"Unexpected error: {deleted.Message}");
            }


                
            
        }

        public async Task<OperationResult<List<Appointment>>> GetAllAppointmentsToDay()
        {

            var list = await _repo.GetAllAppointmentsToDay();

            if (list.ResultType == DataLayerResult.Conflict)
                return OperationResult<List<Appointment>>.NotFound("No appointments found for today.");

            if (list.ResultType == DataLayerResult.InternalError)
                return OperationResult<List<Appointment>>.InternalError($"Unexpected error: {list.Message}");

            var mapped = list.Data.Select(a => new Appointment(a)).ToList();
            return OperationResult<List<Appointment>>.Success(mapped);





        }



        public List<Appointment> GetAllAppointment()
        {
            var appointment = new List<Appointment>();

            var fd = _repo.GetAllAppointment();
            foreach (var f in fd.Result.Data)
            {
                appointment.Add(new Appointment(f));
            }
            return appointment ;

        }

        public  async Task<OperationResult<Appointment>> GetAppointmentByID(int id)
        {
            if (id <= 0) return OperationResult<Appointment>.ValidationError("id is not vaild");

            var appointment =await _repo.GetAppointmentByID( id);
            switch (appointment.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<Appointment>.Success(new Appointment(appointment.Data));
                case DataLayerResult.Conflict:
                    return OperationResult<Appointment>.NotFound("Appointmentid  not found.");
                    default:
                    return OperationResult<Appointment>.InternalError($"Unexpected error: {appointment.Message}");

            }


            


        }
        public async Task<OperationResult<List<AppointmentCalendarDTO>>> GetTodayAppointmentsByDoctorID(int doctorId)
        {
            var appointment = await _repo
                .GetAllAppointmentsToDayByDoctorID(doctorId);

            switch (appointment.ResultType)
            {
                case DataLayerResult.Success:
                    {
                        var dtoList =
                            AppointmentCalendarDTO.FromEntities(appointment.Data);

                        return OperationResult<List<AppointmentCalendarDTO>>
                            .Success(dtoList);
                    }

                case DataLayerResult.NotFound:
                    return OperationResult<List<AppointmentCalendarDTO>>
                        .NotFound("No appointments found today.");

                case DataLayerResult.Conflict:
                    return OperationResult<List<AppointmentCalendarDTO>>
                        .Conflict("Conflict occurred while fetching appointments.");

                default:
                    return OperationResult<List<AppointmentCalendarDTO>>
                        .InternalError(
                            $"Unexpected error: {appointment.Message}");
            }
        }




    }
    }


