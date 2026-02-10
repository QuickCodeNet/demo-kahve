using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.Demo-kahve.ProductionModuleModule.Application.Services.RoastingProcess; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Dtos.RoastingProcess; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.Common.Helpers; using  QuickCode . Demo
-kahve.Common.Models;
namespace QuickCode.Demo - kahve . ProductionModuleModule . Application . Tests . Services . RoastingProcess {
    public class RoastingProcessServiceDeleteTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IRoastingProcessRepository> _repositoryMock;
        private readonly Mock<ILogger<RoastingProcessService>> _loggerMock;
        private readonly RoastingProcessService _service;
        public RoastingProcessServiceDeleteTests()
        {
            _repositoryMock = new Mock<IRoastingProcessRepository>();
            _loggerMock = new Mock<ILogger<RoastingProcessService>>();
            _service = new RoastingProcessService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task DeleteItemAsync_Should_Return_Success_When_Item_Exists()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<RoastingProcessDto>("tr");
            var fakeGetResponse = new RepoResponse<RoastingProcessDto>(fakeDto, "Success");
            var fakeDeleteResponse = new RepoResponse<bool>(true, "Success");
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            _repositoryMock.Setup(r => r.DeleteAsync(It.IsAny<RoastingProcessDto>())).ReturnsAsync(fakeDeleteResponse);
            // Act
            var result = await _service.DeleteItemAsync(fakeDto.Id);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.True(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<RoastingProcessDto>()), Times.Once);
        }

        [Fact]
        public async Task DeleteItemAsync_Should_Return_NotFound_When_Item_Does_Not_Exist()
        {
            var fakeDto = TestDataGenerator.CreateFake<RoastingProcessDto>("tr");
            // Arrange
            var fakeGetResponse = new RepoResponse<RoastingProcessDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            // Act
            var result = await _service.DeleteItemAsync(fakeDto.Id);
            // Assert
            Assert.Equal(ResultCodeNotFound, result.Code);
            Assert.False(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<RoastingProcessDto>()), Times.Never);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}