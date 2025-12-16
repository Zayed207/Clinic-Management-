using AutoMapper;
using BusinessLayer.BusinessLogic;
using BusinessLayer.DTOsPresentation.ClinicDTOs;
using BusinessLayer;
using DataLayer.Contract;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DataLayer.Data;
using DataLayer.Entities;

namespace Clinic_Test.Clinic.Test
{
    public  class UpdateClinicMethod
    {
        [Fact]
        public async Task UpdateClinic_WhenValidationFails_ReturnsValidationError()
        {
            // Arrange (INVALID request)
            var request = new ClinicRequestDTO(); // values missing → validation fails

            var repoMock = new Mock<IClinicRepository>();
            var service = new ClinicServices(repoMock.Object, new Mock<IMapper>().Object);

            // Act
            var result = await service.UpdateClinic(1,request);

            // Assert
            Assert.Equal(ResultStatus.ValidationError, result.Status);

           
        }
        [Fact]
        public async Task UpdateClinic_WhenClinicNameExists_ReturnsConflict()
        {
            // Arrange 
            var request = new ClinicRequestDTO();

            var repoMock = new Mock<IClinicRepository>();
            repoMock
                .Setup(r => r.IsClinicExiset(It.IsAny<string>()))
                .ReturnsAsync(DataLayerOperationResult<bool>.SuccessOperation(true)); // exists

            var service = new ClinicServices(repoMock.Object, new Mock<IMapper>().Object);

            // Act
            var result = await service.UpdateClinic(1,request);

            // Assert

        }
        [Fact]
        public async Task UpdateClinic_WhenUpdateSucceeds_ReturnsSuccess()
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
                .Setup(r => r.UpdateClinic(It.IsAny<ClinicEntity>()))
                .ReturnsAsync(DataLayerOperationResult<bool>.SuccessOperation(true)); 


            var service = new ClinicServices(repoMock.Object, new Mock<IMapper>().Object);

            // Act
            var result = await service.UpdateClinic(1, request);

            // Assert
            Assert.Equal(ResultStatus.Success, result.Status);

        }


    }
}
