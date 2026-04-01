using AutoMapper;
using BusinessLayer;
using BusinessLayer.DTOsPresentation.DoctorDTO;
using DataLayer.Contract;
using DataLayer.Data;
using DataLayer.Entities;
using Moq;
using System.Threading.Tasks;
using Xunit;
using BusinessLayer.BusinessLogic;

namespace Clinic_Test.Doctor.Test
{
    public class UpdateDoctorMethod
    {
        [Fact]
        public async Task UpdateDoctor_WhenNotFound_ReturnsNotFoundError()
        {
            // Arrange
            var request = new DoctorRequestDTO();
            var repoMock = new Mock<IDoctorRepository>();
            var mapperMock = new Mock<IMapper>();

            repoMock.Setup(r => r.IsDoctorExistByEmployeeID(It.IsAny<int>()))
                .ReturnsAsync(DataLayerOperationResult<bool>.Fail("Not exists"));

            var service = new DoctorServices(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.UpdateDoctor(request, 1);

            // Assert
            Assert.Equal(ResultStatus.NotFound, result.Status);
        }

        [Fact]
        public async Task UpdateDoctor_WhenValid_ReturnsSuccess()
        {
            // Arrange
            var request = new DoctorRequestDTO();
            var repoMock = new Mock<IDoctorRepository>();
            var mapperMock = new Mock<IMapper>();

            repoMock.Setup(r => r.IsDoctorExistByEmployeeID(It.IsAny<int>()))
                .ReturnsAsync(DataLayerOperationResult<bool>.SuccessOperation(true));

            repoMock.Setup(r => r.UpdateDoctor(It.IsAny<DoctorEntity>()))
                .ReturnsAsync(DataLayerOperationResult<bool>.SuccessOperation(true));

            var service = new DoctorServices(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.UpdateDoctor(request, 2);

            // Assert
            Assert.Equal(ResultStatus.Success, result.Status);
        }
    }
}
