using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demo-kahve.Common.Models; using  QuickCode . Demo
-kahve.RecipeModuleModule.Domain.Entities; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Dtos.RecipeCategory;
namespace QuickCode.Demo - kahve . RecipeModuleModule . Application . Services . RecipeCategory {
    public partial class RecipeCategoryService : IRecipeCategoryService
    {
        private readonly ILogger<RecipeCategoryService> _logger;
        private readonly IRecipeCategoryRepository _repository;
        public RecipeCategoryService(ILogger<RecipeCategoryService> logger, IRecipeCategoryRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<RecipeCategoryDto>> InsertAsync(RecipeCategoryDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(RecipeCategoryDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, RecipeCategoryDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<RecipeCategoryDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<RecipeCategoryDto>> GetItemAsync(int id)
        {
            var returnValue = await _repository.GetByPkAsync(id);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteItemAsync(int id)
        {
            var deleteItem = await _repository.GetByPkAsync(id);
            if (deleteItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.DeleteAsync(deleteItem.Value);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> TotalItemCountAsync()
        {
            var returnValue = await _repository.CountAsync();
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool recipeCategoriesIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(recipeCategoriesIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetRecipeCategoryAssignmentsForRecipeCategoriesResponseDto>>> GetRecipeCategoryAssignmentsForRecipeCategoriesAsync(int recipeCategoriesId)
        {
            var returnValue = await _repository.GetRecipeCategoryAssignmentsForRecipeCategoriesAsync(recipeCategoriesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetRecipeCategoryAssignmentsForRecipeCategoriesResponseDto>> GetRecipeCategoryAssignmentsForRecipeCategoriesDetailsAsync(int recipeCategoriesId, int recipeCategoryAssignmentsId)
        {
            var returnValue = await _repository.GetRecipeCategoryAssignmentsForRecipeCategoriesDetailsAsync(recipeCategoriesId, recipeCategoryAssignmentsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> DeactivateAsync(int recipeCategoriesId, DeactivateRequestDto updateRequest)
        {
            var returnValue = await _repository.DeactivateAsync(recipeCategoriesId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}