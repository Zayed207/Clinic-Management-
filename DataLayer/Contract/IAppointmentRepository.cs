using DataLayer.Entities;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Contract
{
    using System.Collections.Generic;



    public interface IAppointmentRepository
    {
        Task<bool> IsAppointmentUnavailable(DateTime date);
         Task<int> AddAppointment(AppointmentEntity entity);
        Task<bool> UpdateAppointment(AppointmentEntity entity);
        Task< bool >DeleteAppointment(int id);
        Task< bool >DeleteAppointmentByPatientID(int patientId);
        //bool DeleteAppointmentByPatientID(int patientId);
        Task< List<AppointmentEntity> >GetAllAppointmentsToDayByDoctorID(int DoctorID);
        Task<List<AppointmentEntity> >GetAllAppointmentsToDayByClinicName(string clinicname);
         Task< List<AppointmentEntity> >GetAllAppointmentsToDay();
    }
}
