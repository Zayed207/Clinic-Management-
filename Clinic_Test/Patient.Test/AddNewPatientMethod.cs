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
    public class AddNewPatientMethod
    {
        [Fact]
        public async Task AddNewPatient_WhenFails_ReturnsInternalError()
        {
            // Arrange
            var request = new PatientRequestDTO { EmergencyContactName = "John Doe" };
            var repoMock = new Mock<IPatientRepository>();
            var mapperMock = new Mock<IMapper>();

            repoMock.Setup(r => r.AddPatient(It.IsAny<PatientEntity>()))
                .ReturnsAsync(DataLayerOperationResult<int>.Fail()); // Assuming Fail returns InternalError

            var service = new PatientServices(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.AddNewPatient(request);

            // Assert
            Assert.Equal(ResultStatus.Conflict, result.Status);
        }

        [Fact]
        public async Task AddNewPatient_WhenValid_ReturnsSuccess()
        {
            // Arrange
            var request = new PatientRequestDTO { EmergencyContactName = "Jane Doe" };
            var repoMock = new Mock<IPatientRepository>();
            var mapperMock = new Mock<IMapper>();

            repoMock.Setup(r => r.AddPatient(It.IsAny<PatientEntity>()))
                .ReturnsAsync(DataLayerOperationResult<int>.SuccessOperation(1));

            var service = new PatientServices(repoMock.Object, mapperMock.Object);

            // Act
            var result = await service.AddNewPatient(request);

            // Assert
            Assert.Equal(ResultStatus.Success, result.Status);
        }
    }
}
