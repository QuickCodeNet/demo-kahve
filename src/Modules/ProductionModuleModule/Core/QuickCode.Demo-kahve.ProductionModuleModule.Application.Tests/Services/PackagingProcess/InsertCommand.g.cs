using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.Demo-kahve.ProductionModuleModule.Application.Services.PackagingProcess; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Dtos.PackagingProcess; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.Common.Helpers; using  QuickCode . Demo
-kahve.Common.Models;
namespace QuickCode.Demo - kahve . ProductionModuleModule . Application . Tests . Services . PackagingProcess {
    public class InsertPackagingProcessCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IPackagingProcessRepository> _repositoryMock;
        private readonly Mock<ILogger<PackagingProcessService>> _loggerMock;
        private readonly PackagingProcessService _service;
        public InsertPackagingProcessCommandTests()
        {
            _repositoryMock = new Mock<IPackagingProcessRepository>();
            _loggerMock = new Mock<ILogger<PackagingProcessService>>();
            _service = new PackagingProcessService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<PackagingProcessDto>("tr");
            var fakeResponse = new RepoResponse<PackagingProcessDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<PackagingProcessDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<PackagingProcessDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<PackagingProcessDto>("tr");
            var fakeResponse = new RepoResponse<PackagingProcessDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<PackagingProcessDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeNotFound, result.Code);
            Assert.Null(result.Value);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}