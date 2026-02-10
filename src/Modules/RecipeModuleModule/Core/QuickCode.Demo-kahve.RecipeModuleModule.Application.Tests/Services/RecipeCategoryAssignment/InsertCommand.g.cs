using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.Demo-kahve.RecipeModuleModule.Application.Services.RecipeCategoryAssignment; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Dtos.RecipeCategoryAssignment; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.Common.Helpers; using  QuickCode . Demo
-kahve.Common.Models;
namespace QuickCode.Demo - kahve . RecipeModuleModule . Application . Tests . Services . RecipeCategoryAssignment {
    public class InsertRecipeCategoryAssignmentCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IRecipeCategoryAssignmentRepository> _repositoryMock;
        private readonly Mock<ILogger<RecipeCategoryAssignmentService>> _loggerMock;
        private readonly RecipeCategoryAssignmentService _service;
        public InsertRecipeCategoryAssignmentCommandTests()
        {
            _repositoryMock = new Mock<IRecipeCategoryAssignmentRepository>();
            _loggerMock = new Mock<ILogger<RecipeCategoryAssignmentService>>();
            _service = new RecipeCategoryAssignmentService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<RecipeCategoryAssignmentDto>("tr");
            var fakeResponse = new RepoResponse<RecipeCategoryAssignmentDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<RecipeCategoryAssignmentDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<RecipeCategoryAssignmentDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<RecipeCategoryAssignmentDto>("tr");
            var fakeResponse = new RepoResponse<RecipeCategoryAssignmentDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<RecipeCategoryAssignmentDto>())).ReturnsAsync(fakeResponse);
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