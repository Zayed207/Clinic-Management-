using Xunit;

using DataLayer.Contract;
using BusinessLayer;
using BusinessLayer.DTOsPresentation;
using BusinessLayer.Validations;
using BusinessLayer.BusinessLogic;
using Moq;
using AutoMapper;
using DataLayer.Data;
using DataLayer.Entities;

namespace Clinic_Test.Appointment.Test.CreateAppointment
{
    public class CreateAppointment
    {
        [Fact]
        public void CreateAppointment_CheckValidation_ReturnValidationErorr()
        {
            var request = new AppointmentRequestDTO(0, -1, 22, 33, DateTime.Now, 20,
                BusinessLayer.Appointment.enAppointmentStatus.Pending, BusinessLayer.Appointment.enAppointmentType.InitialConsultation
                , BusinessLayer.Appointment.enConsultationType.Preventive, "null");

            //
            var appointmentservices = new AppointmentServices(new Mock<IAppointmentRepository>().Object, new Mock<IMapper>().Object);

            var validate = Appoinment_V.CreateAppointmentCheckObject(request);

            var expected = OperationResult<bool>.ValidationError("The appointment must to have clinic and doctor and patient and date bigger than today");
            Assert.Equal(expected.Status, validate.Status);
        }
        public void CreateAppointment_AppointmentNotAvailable_ReturnConflict()
        {
            var request = DateTime.MinValue;
               

            //
            var appointmentservices = new Mock<IAppointmentRepository>().Object;

            var validate = appointmentservices.IsAppointmentAvailable(request);

            var expected = OperationResult<bool>.ValidationError("The appointment must to have clinic and doctor and patient and date bigger than today");
            Assert.Equal(expected.Status.ToString(), validate.Status.ToString());
        }

      
    }
}
