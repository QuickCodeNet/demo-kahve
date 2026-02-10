using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.Demo-kahve.RecipeModuleModule.Application.Services.RecipeIngredient; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Dtos.RecipeIngredient; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.Common.Helpers; using  QuickCode . Demo
-kahve.Common.Models;
namespace QuickCode.Demo - kahve . RecipeModuleModule . Application . Tests . Services . RecipeIngredient {
    public class RecipeIngredientServiceDeleteTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IRecipeIngredientRepository> _repositoryMock;
        private readonly Mock<ILogger<RecipeIngredientService>> _loggerMock;
        private readonly RecipeIngredientService _service;
        public RecipeIngredientServiceDeleteTests()
        {
            _repositoryMock = new Mock<IRecipeIngredientRepository>();
            _loggerMock = new Mock<ILogger<RecipeIngredientService>>();
            _service = new RecipeIngredientService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task DeleteItemAsync_Should_Return_Success_When_Item_Exists()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<RecipeIngredientDto>("tr");
            var fakeGetResponse = new RepoResponse<RecipeIngredientDto>(fakeDto, "Success");
            var fakeDeleteResponse = new RepoResponse<bool>(true, "Success");
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            _repositoryMock.Setup(r => r.DeleteAsync(It.IsAny<RecipeIngredientDto>())).ReturnsAsync(fakeDeleteResponse);
            // Act
            var result = await _service.DeleteItemAsync(fakeDto.Id);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.True(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<RecipeIngredientDto>()), Times.Once);
        }

        [Fact]
        public async Task DeleteItemAsync_Should_Return_NotFound_When_Item_Does_Not_Exist()
        {
            var fakeDto = TestDataGenerator.CreateFake<RecipeIngredientDto>("tr");
            // Arrange
            var fakeGetResponse = new RepoResponse<RecipeIngredientDto>
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
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<RecipeIngredientDto>()), Times.Never);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}