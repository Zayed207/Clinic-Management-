using BusinessLayer.BusinessLogic;
using BusinessLayer.DTOsPresentation.AppoinntmentsDTOs;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLayer.Appointment;

namespace BusinessLayer.Validations
{
    public class Appoinment_V
    {
        public static OperationResult<bool> CreateAppointmentCheckObject(AppointmentRequestDTO e)
        {
             if (e.ClinicID <= 0 || e.DoctorID <= 0 || e.PatientID <= 0)
            {

                return OperationResult<bool>.ValidationError("The appointment must to have clinic and doctor and patient and date bigger than today");





            }
           else if (!Enum.IsDefined(typeof(enAppointmentType), e.AppointmentTypeID)
                ||! Enum.IsDefined(typeof(enConsultationType), e.ConsultationModeID) || !Enum.IsDefined(typeof(enAppointmentStatus), e.StatusID))
            {
                return OperationResult<bool>.ValidationError("one or more of AppointmentType, ConsultationType or AppointmentStatus not exist");

            }
            
            return OperationResult<bool>.Validate("");
        }
    }
}
