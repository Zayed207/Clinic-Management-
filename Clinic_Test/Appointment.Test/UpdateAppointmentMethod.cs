using AutoMapper;
using BusinessLayer.BusinessLogic;
using BusinessLayer.DTOsPresentation.AppoinntmentsDTOs;
using BusinessLayer;
using DataLayer.Contract;
using DataLayer.Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLayer.Appointment;
using Xunit;
using DataLayer.Entities;

namespace Clinic_Test.Appointment.Test
{
    public class UpdateAppointmentMethod
    {
        [Fact]
    public async Task UpdateAppointment_WhenValidationFails_ReturnsValidationError()
        {
            // Arrange (invalid request)
            var request = new AppointmentRequestDTO(
                0, 0, 0, 0,
                DateTime.Now.AddDays(-1),
                0,
                enAppointmentStatus.Pending,
                enAppointmentType.InitialConsultation,
                enConsultationType.Preventive,
                ""
            );

            var repoMock = new Mock<IAppointmentRepository>();

            var service = new AppointmentServices(
                repoMock.Object,
                new Mock<IMapper>().Object
            );

            // Act
            var result = await service.UpdateAppointment(request);

            var expected = ResultStatus.ValidationError;
            // Assert
            Assert.Equal(expected, result.Status);

         

         
        }

        [Fact]
    public async Task UpdateAppointment_WhenAppointmentNotAvailable_ReturnsNotFound()
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
        var result = await service.UpdateAppointment(request);

        // Assert
        Assert.Equal(ResultStatus.NotFound, result.Status);

       
     
        
    }
       
        
        [Fact]
      public async Task UpdateAppointment_WhenUpdateSucceeds_ReturnsUpdated()
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
                .ReturnsAsync(DataLayerOperationResult<bool>.SuccessOperation(true));

            repoMock
                .Setup(r => r.UpdateAppointment(It.IsAny<AppointmentEntity>()))
                .ReturnsAsync(DataLayerOperationResult<bool>.SuccessOperation(true));

            var service = new AppointmentServices(
                repoMock.Object,
                new Mock<IMapper>().Object
            );

            // Act
            var result = await service.UpdateAppointment(request);

            var expected = OperationResult<bool>.Updated("Appointment updated successfully."); ;
            // Assert
            Assert.Equal(expected.Status, result.Status);

          
        }


    }
}
