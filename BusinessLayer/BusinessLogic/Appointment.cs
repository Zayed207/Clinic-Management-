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

namespace BusinessLayer
{
    public class Appointment
    {
       

        
        public int Appointment_ID { get; set; }
        public int Patient_ID_FK { get; set; }
        public int Doctor_ID_FK { get; set; }
        public int Clinic_ID_FK { get; set; }
        public DateTime Appointment_Date_Time { get; set; }
        public int? Appointment_Duration_Minutes { get; set; }
        public enAppointmentStatus? Status_ID_FK { get; set; }
        public enAppointmentType    Appointment_Type_ID_FK { get; set; }
        public enConsultationType  ? Consultation_Mode_ID_FK { get; set; }

        public string? Notes { get; set; }

        public Appointment(AppointmentRequestDTO appointment)
        {
            
            Patient_ID_FK = appointment.Patient_ID_FK;
            Doctor_ID_FK = appointment.Doctor_ID_FK;
            Clinic_ID_FK = appointment.Clinic_ID_FK;
            Appointment_Date_Time = appointment.Appointment_Date_Time;
            Appointment_Duration_Minutes = appointment.Appointment_Duration_Minutes;
            Status_ID_FK = appointment.Status_ID_FK;
            Appointment_Type_ID_FK = appointment.Appointment_Type_ID_FK;
            Consultation_Mode_ID_FK = appointment.Consultation_Mode_ID_FK;
            Notes = appointment
                .Notes;
          
        }
        public Appointment(AppointmentEntity appointment)
        {
            Appointment_ID = appointment.Appointment_ID;
            Patient_ID_FK = appointment.Patient_ID_FK;
            Doctor_ID_FK = appointment.Doctor_ID_FK;
            Clinic_ID_FK = appointment.Clinic_ID_FK;
            Appointment_Date_Time = appointment.Appointment_Date_Time;
            Appointment_Duration_Minutes = appointment.Appointment_Duration_Minutes;
            Status_ID_FK =(enAppointmentStatus)appointment.Status_ID_FK;
            Appointment_Type_ID_FK =(enAppointmentType) appointment.Appointment_Type_ID_FK;
            Consultation_Mode_ID_FK = (enConsultationType)appointment.Consultation_Mode_ID_FK;
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



        public async Task <OperationResult<int>> AddNewAppointment(AppointmentRequestDTO appointment)
        {
            //checked patient and dotor
            try
            {
                int id =await _repo.AddAppointment(_mapper.Map<AppointmentEntity>(appointment));
                if (id > 0)
                {
                    return OperationResult<int>.Success(id, "Appointment created successfully.");
                }
                return OperationResult<int>.InternalError("Failed to create appointment.");
            }
            catch (Exception ex)
            {
                return OperationResult<int>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        public async Task< OperationResult<bool> >UpdateAppointment(AppointmentRequestDTO appointment)
        {
            try
            {
                bool updated =await _repo.UpdateAppointment(_mapper.Map<AppointmentEntity>(new Appointment(appointment)));
                if (updated)
                    return OperationResult<bool>.Updated("Appointment updated successfully.");
                else
                    return OperationResult<bool>.NotFound("Appointment not found or nothing to update.");
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        public async Task< OperationResult<bool> >DeleteAppointment(int id)
        {
            try
            {
                bool deleted =await _repo.DeleteAppointment(id);
                if (deleted)
                    return OperationResult<bool>.Success(true, "Appointment deleted successfully.");
                else
                    return OperationResult<bool>.NotFound("Appointment not found or nothing to delete.");
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        public async Task<OperationResult<bool> >DeleteAppointmentByPatientID(int patientId)
        {
            try
            {
                bool deleted =await _repo.DeleteAppointmentByPatientID(patientId);
                if (deleted)
                    return OperationResult<bool>.Success(true, "Appointment deleted successfully by patient ID.");
                else
                    return OperationResult<bool>.NotFound("No appointment found for the given patient ID.");
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        public async Task< OperationResult<List<Appointment>> >GetAllAppointmentsToDay()
        {
            try
            {
                var list =await _repo.GetAllAppointmentsToDay();
                if (list == null || list.Count == 0)
                    return OperationResult<List<Appointment>>.NotFound("No appointments found for today.");

                var mapped = list.Select(a => new Appointment(a)).ToList();
                return OperationResult<List<Appointment>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return OperationResult<List<Appointment>>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        public async Task <OperationResult<List<Appointment>> >GetAllAppointmentsToDayByDoctorID(int doctorId)
        {
            try
            {
                var list =await _repo.GetAllAppointmentsToDayByDoctorID(doctorId);
                if (list == null || list.Count == 0)
                    return OperationResult<List<Appointment>>.NotFound("No appointments found for this doctor today.");

                var mapped = list.Select(a => new Appointment(a)).ToList();
                return OperationResult<List<Appointment>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return OperationResult<List<Appointment>>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        public async Task<OperationResult<List<Appointment>> >GetAllAppointmentsToDayByClinicName(string clinicName)
        {
            try
            {
                var list =await _repo.GetAllAppointmentsToDayByClinicName(clinicName);
                if (list == null || list.Count == 0)
                    return OperationResult<List<Appointment>>.NotFound("No appointments found for this clinic today.");

                var mapped = list.Select(a => new Appointment(a)).ToList();
                return OperationResult<List<Appointment>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return OperationResult<List<Appointment>>.InternalError($"Unexpected error: {ex.Message}");
            }
        }


    }
}

