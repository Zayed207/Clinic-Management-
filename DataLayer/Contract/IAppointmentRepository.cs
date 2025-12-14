using DataLayer.Entities;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Contract
{
    using DataLayer.Data;
    using DataLayer.ReadModel.Appointment;
    using System.Collections.Generic;



    public interface IAppointmentRepository
    {
       public  Task<DataLayerOperationResult<bool>> IsAppointmentAvailable(DateTime date);
       public   Task<DataLayerOperationResult<int>> AddNewAppointment(AppointmentEntity entity);
       public  Task<DataLayerOperationResult<bool>> UpdateAppointment(AppointmentEntity entity);
       public  Task< DataLayerOperationResult<bool> >DeleteAppointment(int id);
       public  Task< DataLayerOperationResult<bool> >DeleteAppointmentByPatientID(int patientId);
        public  Task<DataLayerOperationResult<List<AppointmentCalendar>>> GetAllAppointmentsToDayByDoctorID(int DoctorID);
       public  Task<DataLayerOperationResult<List<AppointmentsDetails>>> GetAllAppointmentsToDayByClinicName(string clinicname);
       public   Task<DataLayerOperationResult<List<AppointmentEntity>> >GetAllAppointmentsToDay();
       public  Task< DataLayerOperationResult<List<AppointmentEntity>> >GetAllAppointment(); 
        public Task<DataLayerOperationResult<AppointmentEntity>> GetAppointmentByID(int id);

    }
}
