using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.Demo-kahve.RecipeModuleModule.Application.Services.RecipeCategory; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Dtos.RecipeCategory; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.Common.Helpers; using  QuickCode . Demo
-kahve.Common.Models;
namespace QuickCode.Demo - kahve . RecipeModuleModule . Application . Tests . Services . RecipeCategory {
    public class InsertRecipeCategoryCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IRecipeCategoryRepository> _repositoryMock;
        private readonly Mock<ILogger<RecipeCategoryService>> _loggerMock;
        private readonly RecipeCategoryService _service;
        public InsertRecipeCategoryCommandTests()
        {
            _repositoryMock = new Mock<IRecipeCategoryRepository>();
            _loggerMock = new Mock<ILogger<RecipeCategoryService>>();
            _service = new RecipeCategoryService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<RecipeCategoryDto>("tr");
            var fakeResponse = new RepoResponse<RecipeCategoryDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<RecipeCategoryDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<RecipeCategoryDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<RecipeCategoryDto>("tr");
            var fakeResponse = new RepoResponse<RecipeCategoryDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<RecipeCategoryDto>())).ReturnsAsync(fakeResponse);
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