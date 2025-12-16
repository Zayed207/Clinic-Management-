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
using BusinessLayer.DTOsPresentation.AppoinntmentsDTOs;
using static BusinessLayer.Appointment;

namespace Clinic_Test.Appointment.Test
{
    public class CreateAppointmentMethod
    {
        [Fact]
        public void CreateAppointment_CheckValidation_ReturnValidationErorr()
        {
            var request = new AppointmentRequestDTO(0, -1, 22, 33, DateTime.Now, 20,
                enAppointmentStatus.Pending, enAppointmentType.InitialConsultation
                , enConsultationType.Preventive, "null");

            //
            var appointmentservices = new AppointmentServices(new Mock<IAppointmentRepository>().Object, new Mock<IMapper>().Object);

            var validate = Appoinment_V.CreateAppointmentCheckObject(request);

            var expected = OperationResult<bool>.ValidationError("The appointment must to have clinic and doctor and patient and date bigger than today");
            Assert.Equal(expected.Status, validate.Status);
        }
     
        [Fact]
        public async Task CreateAppointment_AppointmentNotAvailable_ReturnConflicst()
        {
            // Arrange
            var request = new AppointmentRequestDTO(
                1, 1, 1, 1,
                DateTime.Now.AddDays(1),
                20,
                enAppointmentStatus.Pending,
                enAppointmentType.InitialConsultation,
                enConsultationType.Preventive,
                "note"
            );

            var repoMock = new Mock<IAppointmentRepository>();

            repoMock
                .Setup(r => r.IsAppointmentAvailable(It.IsAny<DateTime>()))
                .ReturnsAsync(DataLayerOperationResult<bool>.Fail()); // Conflict

            var service = new AppointmentServices(
                repoMock.Object,
                new Mock<IMapper>().Object
            );

            // Act
            var result = await service.CreateAppointment(request);

            // Assert
            Assert.Equal(ResultStatus.NotFound, result.Status);
            Assert.Equal("The Appointment is Unavalible", result.Message);
        }

    }
}
