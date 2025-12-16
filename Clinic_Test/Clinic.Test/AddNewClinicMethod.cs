using AutoMapper;
using BusinessLayer.BusinessLogic;
using BusinessLayer.DTOsPresentation.ClinicDTOs;
using BusinessLayer;
using DataLayer.Contract;
using DataLayer.Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DataLayer.Entities;

namespace Clinic_Test.Clinic.Test
{
    public class AddNewClinicMethod
    {
        [Fact]
        public async Task AddNewClinic_WhenValidationFails_ReturnsValidationError()
        {
            // Arrange
            var request = new ClinicRequestDTO();

            var repoMock = new Mock<IClinicRepository>();
            var service = new ClinicServices(repoMock.Object, new Mock<IMapper>().Object);

            // Act
            var result = await service.AddNewClinic(request);

            // Assert
            var expected = ResultStatus.ValidationError;
            Assert.Equal(expected, result.Status);


        }
   
        [Fact]
        public async Task AddNewClinic_WhenClinicNameExists_ReturnsConflict()
        {
            // Arrange
            var request = new ClinicRequestDTO
            {
                ClinicName = "Smile Clinic",
                City = "Cairo",
                LocationDescription = "Desc"
            }; 

            var repoMock = new Mock<IClinicRepository>();
            repoMock
                .Setup(r => r.IsClinicExiset(It.IsAny<string>()))
                .ReturnsAsync(DataLayerOperationResult<bool>.SuccessOperation(true));

            var service = new ClinicServices(repoMock.Object, new Mock<IMapper>().Object);

            // Act
            var result = await service.AddNewClinic(request);

            // Assert
            var expected = ResultStatus.Conflict;
            Assert.Equal(expected, result.Status);

        
        }

        [Fact]
        public async Task AddNewClinic_WhenValid_ReturnsSuccess()
        {
            // Arrange
            var request = new ClinicRequestDTO
            {
                ClinicName = "Smile Clinic",
                City = "Cairo",
                LocationDescription = "Desc"
            };

            var repoMock = new Mock<IClinicRepository>();

            repoMock
                .Setup(r => r.IsClinicExiset(It.IsAny<string>()))
                .ReturnsAsync(DataLayerOperationResult<bool>.Fail());

            repoMock
                .Setup(r => r.AddClinic(It.IsAny<ClinicEntity>()))
                .ReturnsAsync(DataLayerOperationResult<int>.SuccessOperation(1));

            var service = new ClinicServices(repoMock.Object, new Mock<IMapper>().Object);

            // Act
            var result = await service.AddNewClinic(request);

            // Assert
            var expected = ResultStatus.Success;
            Assert.Equal(expected, result.Status);

        }

    }
}
