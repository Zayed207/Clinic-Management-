using AutoMapper;
using BusinessLayer;
using DataLayer.Contract;
using DataLayer.Data;
using Moq;
using System.Threading.Tasks;
using Xunit;
using BusinessLayer.BusinessLogic;

namespace Clinic_Test.Patient.Test
{
    public class DeletePatientMethod
    {
        [Fact]
        public async Task DeleteByPatientID_WhenInvalidId_ReturnsValidationError()
        {
            // Arrange
            var repoMock = new Mock<IPatientRepository>();
            var mapperMock = new Mock<IMapper>();
            var service = new PatientServices(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.DeleteByPatientID(0);

            // Assert
            Assert.Equal(ResultStatus.ValidationError, result.Status);
        }

        [Fact]
        public async Task DeleteByPatientID_WhenValid_ReturnsSuccess()
        {
            // Arrange
            var repoMock = new Mock<IPatientRepository>();
            var mapperMock = new Mock<IMapper>();

            repoMock.Setup(r => r.DeletePatient(It.IsAny<int>()))
                .ReturnsAsync(DataLayerOperationResult<bool>.SuccessOperation(true));

            var service = new PatientServices(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.DeleteByPatientID(1);

            // Assert
            Assert.Equal(ResultStatus.Success, result.Status);
        }
        
        [Fact]
        public async Task DeleteByPatientID_WhenNotFound_ReturnsNotFound()
        {
            // Arrange
            var repoMock = new Mock<IPatientRepository>();
            var mapperMock = new Mock<IMapper>();

            repoMock.Setup(r => r.DeletePatient(It.IsAny<int>()))
                .ReturnsAsync(DataLayerOperationResult<bool>.Fail("Not found"));

            var service = new PatientServices(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.DeleteByPatientID(1);

            // Assert
            Assert.Equal(ResultStatus.NotFound, result.Status);
        }
    }
}
