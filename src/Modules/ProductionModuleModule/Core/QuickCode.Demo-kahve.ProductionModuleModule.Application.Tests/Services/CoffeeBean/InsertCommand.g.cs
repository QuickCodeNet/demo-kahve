using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.Demo-kahve.ProductionModuleModule.Application.Services.CoffeeBean; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Dtos.CoffeeBean; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.Common.Helpers; using  QuickCode . Demo
-kahve.Common.Models;
namespace QuickCode.Demo - kahve . ProductionModuleModule . Application . Tests . Services . CoffeeBean {
    public class InsertCoffeeBeanCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<ICoffeeBeanRepository> _repositoryMock;
        private readonly Mock<ILogger<CoffeeBeanService>> _loggerMock;
        private readonly CoffeeBeanService _service;
        public InsertCoffeeBeanCommandTests()
        {
            _repositoryMock = new Mock<ICoffeeBeanRepository>();
            _loggerMock = new Mock<ILogger<CoffeeBeanService>>();
            _service = new CoffeeBeanService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<CoffeeBeanDto>("tr");
            var fakeResponse = new RepoResponse<CoffeeBeanDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<CoffeeBeanDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<CoffeeBeanDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<CoffeeBeanDto>("tr");
            var fakeResponse = new RepoResponse<CoffeeBeanDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<CoffeeBeanDto>())).ReturnsAsync(fakeResponse);
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