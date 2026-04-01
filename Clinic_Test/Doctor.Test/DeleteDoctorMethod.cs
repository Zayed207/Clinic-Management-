using AutoMapper;
using BusinessLayer;
using DataLayer.Contract;
using DataLayer.Data;
using Moq;
using System.Threading.Tasks;
using Xunit;
using BusinessLayer.BusinessLogic;

namespace Clinic_Test.Doctor.Test
{
    public class DeleteDoctorMethod
    {
        [Fact]
        public async Task DeleteDoctorByEmployeeID_WhenInvalidId_ReturnsValidationError()
        {
            // Arrange
            var repoMock = new Mock<IDoctorRepository>();
            var mapperMock = new Mock<IMapper>();
            var service = new DoctorServices(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.DeleteDoctorByEmployeeID(0);

            // Assert
            Assert.Equal(ResultStatus.ValidationError, result.Status);
        }

        [Fact]
        public async Task DeleteDoctorByEmployeeID_WhenValid_ReturnsSuccess()
        {
            // Arrange
            var repoMock = new Mock<IDoctorRepository>();
            var mapperMock = new Mock<IMapper>();

            repoMock.Setup(r => r.DeleteDoctorByEmployeeID(It.IsAny<int>()))
                .ReturnsAsync(DataLayerOperationResult<bool>.SuccessOperation(true));

            var service = new DoctorServices(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.DeleteDoctorByEmployeeID(1);

            // Assert
            Assert.Equal(ResultStatus.Success, result.Status);
        }
        
        [Fact]
        public async Task DeleteDoctorByEmployeeID_WhenNotFound_ReturnsNotFound()
        {
            // Arrange
            var repoMock = new Mock<IDoctorRepository>();
            var mapperMock = new Mock<IMapper>();

            repoMock.Setup(r => r.DeleteDoctorByEmployeeID(It.IsAny<int>()))
                .ReturnsAsync(DataLayerOperationResult<bool>.Fail("Not found"));

            var service = new DoctorServices(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.DeleteDoctorByEmployeeID(1);

            // Assert
            Assert.Equal(ResultStatus.NotFound, result.Status);
        }
    }
}
