using AutoMapper;
using BusinessLayer;
using BusinessLayer.DTOsPresentation;
using DataLayer.Contract;
using DataLayer.Data;
using DataLayer.Entities;
using Moq;
using System.Threading.Tasks;
using Xunit;
using BusinessLayer.BusinessLogic;

namespace Clinic_Test.Patient.Test
{
    public class UpdatePatientMethod
    {
        [Fact]
        public async Task UpdatePatient_WhenNotFound_ReturnsNotFoundError()
        {
            // Arrange
            var request = new PatientRequestDTO();
            var repoMock = new Mock<IPatientRepository>();
            var mapperMock = new Mock<IMapper>();

            repoMock.Setup(r => r.UpdatePatient(It.IsAny<PatientEntity>()))
                .ReturnsAsync(DataLayerOperationResult<bool>.Fail("Not exists"));

            var service = new PatientServices(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.UpdatePatient(request);

            // Assert
            Assert.Equal(ResultStatus.NotFound, result.Status);
        }

        [Fact]
        public async Task UpdatePatient_WhenValid_ReturnsSuccess()
        {
            // Arrange
            var request = new PatientRequestDTO();
            var repoMock = new Mock<IPatientRepository>();
            var mapperMock = new Mock<IMapper>();

            repoMock.Setup(r => r.UpdatePatient(It.IsAny<PatientEntity>()))
                .ReturnsAsync(DataLayerOperationResult<bool>.SuccessOperation(true));

            var service = new PatientServices(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.UpdatePatient(request);

            // Assert
            Assert.Equal(ResultStatus.Success, result.Status);
        }
    }
}
