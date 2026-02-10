using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.Demo-kahve.RecipeModuleModule.Application.Services.RecipeEquipment; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Dtos.RecipeEquipment; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.Common.Helpers; using  QuickCode . Demo
-kahve.Common.Models;
namespace QuickCode.Demo - kahve . RecipeModuleModule . Application . Tests . Services . RecipeEquipment {
    public class UpdateRecipeEquipmentCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IRecipeEquipmentRepository> _repositoryMock;
        private readonly Mock<ILogger<RecipeEquipmentService>> _loggerMock;
        private readonly RecipeEquipmentService _service;
        public UpdateRecipeEquipmentCommandTests()
        {
            _repositoryMock = new Mock<IRecipeEquipmentRepository>();
            _loggerMock = new Mock<ILogger<RecipeEquipmentService>>();
            _service = new RecipeEquipmentService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task UpdateAsync_Should_Return_Success_When_Item_Exists()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<RecipeEquipmentDto>("tr");
            var fakeGetResponse = new RepoResponse<RecipeEquipmentDto>(fakeDto, "Success");
            var fakeUpdateResponse = new RepoResponse<bool>(true, "Success");
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            _repositoryMock.Setup(r => r.UpdateAsync(It.IsAny<RecipeEquipmentDto>())).ReturnsAsync(fakeUpdateResponse);
            // Act
            var result = await _service.UpdateAsync(fakeDto.Id, fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.True(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<RecipeEquipmentDto>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_Should_Return_NotFound_When_Item_Does_Not_Exist()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<RecipeEquipmentDto>("tr");
            var fakeGetResponse = new RepoResponse<RecipeEquipmentDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            // Act
            var result = await _service.UpdateAsync(fakeDto.Id, fakeDto);
            // Assert
            Assert.Equal(ResultCodeNotFound, result.Code);
            Assert.False(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<RecipeEquipmentDto>()), Times.Never);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}