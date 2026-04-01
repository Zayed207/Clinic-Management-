using AutoMapper;
using BusinessLayer;
using BusinessLayer.DTOsPresentation.DoctorDTO;
using DataLayer.Contract;
using DataLayer.Data;
using DataLayer.Entities;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using BusinessLayer.BusinessLogic;

namespace Clinic_Test.Doctor.Test
{
    public class AddNewDoctorMethod
    {
        [Fact]
        public async Task AddNewDoctor_WhenConflict_ReturnsConflictError()
        {
            // Arrange
            var request = new DoctorRequestDTO { EmployeeID = 1 };
            var repoMock = new Mock<IDoctorRepository>();
            var mapperMock = new Mock<IMapper>();

            repoMock.Setup(r => r.IsDoctorExistByEmployeeID(It.IsAny<int>()))
                .ReturnsAsync(DataLayerOperationResult<bool>.Fail("Exists"));

            var service = new DoctorServices(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.AddNewDoctor(request);

            // Assert
            Assert.Equal(ResultStatus.Conflict, result.Status);
        }

        [Fact]
        public async Task AddNewDoctor_WhenValid_ReturnsSuccess()
        {
            // Arrange
            var request = new DoctorRequestDTO { EmployeeID = 222, Price = 100 };
            var repoMock = new Mock<IDoctorRepository>();
            var mapperMock = new Mock<IMapper>();

            repoMock.Setup(r => r.IsDoctorExistByEmployeeID(It.IsAny<int>()))
                .ReturnsAsync(DataLayerOperationResult<bool>.Fail());

            repoMock.Setup(r => r.AddDoctor(It.IsAny<DoctorEntity>()))
                .ReturnsAsync(DataLayerOperationResult<int>.SuccessOperation(1));

            var service = new DoctorServices(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.AddNewDoctor(request);

            // Assert
            Assert.Equal(1, result.Data);
        }
    }
}
