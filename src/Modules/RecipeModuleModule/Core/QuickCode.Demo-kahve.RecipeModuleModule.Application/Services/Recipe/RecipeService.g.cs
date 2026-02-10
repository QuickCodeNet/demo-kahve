using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demo-kahve.Common.Models; using  QuickCode . Demo
-kahve.RecipeModuleModule.Domain.Entities; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Dtos.Recipe;
namespace QuickCode.Demo - kahve . RecipeModuleModule . Application . Services . Recipe {
    public partial class RecipeService : IRecipeService
    {
        private readonly ILogger<RecipeService> _logger;
        private readonly IRecipeRepository _repository;
        public RecipeService(ILogger<RecipeService> logger, IRecipeRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<RecipeDto>> InsertAsync(RecipeDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(RecipeDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, RecipeDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<RecipeDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<RecipeDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool recipesIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(recipesIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string recipesRecipeName, int? page, int? size)
        {
            var returnValue = await _repository.SearchByNameAsync(recipesRecipeName, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetRecipeIngredientsForRecipesResponseDto>>> GetRecipeIngredientsForRecipesAsync(int recipesId)
        {
            var returnValue = await _repository.GetRecipeIngredientsForRecipesAsync(recipesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetRecipeIngredientsForRecipesResponseDto>> GetRecipeIngredientsForRecipesDetailsAsync(int recipesId, int recipeIngredientsId)
        {
            var returnValue = await _repository.GetRecipeIngredientsForRecipesDetailsAsync(recipesId, recipeIngredientsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetRecipeEquipmentsForRecipesResponseDto>>> GetRecipeEquipmentsForRecipesAsync(int recipesId)
        {
            var returnValue = await _repository.GetRecipeEquipmentsForRecipesAsync(recipesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetRecipeEquipmentsForRecipesResponseDto>> GetRecipeEquipmentsForRecipesDetailsAsync(int recipesId, int recipeEquipmentsId)
        {
            var returnValue = await _repository.GetRecipeEquipmentsForRecipesDetailsAsync(recipesId, recipeEquipmentsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetRecipeNotesForRecipesResponseDto>>> GetRecipeNotesForRecipesAsync(int recipesId)
        {
            var returnValue = await _repository.GetRecipeNotesForRecipesAsync(recipesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetRecipeNotesForRecipesResponseDto>> GetRecipeNotesForRecipesDetailsAsync(int recipesId, int recipeNotesId)
        {
            var returnValue = await _repository.GetRecipeNotesForRecipesDetailsAsync(recipesId, recipeNotesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetRecipeImagesForRecipesResponseDto>>> GetRecipeImagesForRecipesAsync(int recipesId)
        {
            var returnValue = await _repository.GetRecipeImagesForRecipesAsync(recipesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetRecipeImagesForRecipesResponseDto>> GetRecipeImagesForRecipesDetailsAsync(int recipesId, int recipeImagesId)
        {
            var returnValue = await _repository.GetRecipeImagesForRecipesDetailsAsync(recipesId, recipeImagesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetRecipeCategoryAssignmentsForRecipesResponseDto>>> GetRecipeCategoryAssignmentsForRecipesAsync(int recipesId)
        {
            var returnValue = await _repository.GetRecipeCategoryAssignmentsForRecipesAsync(recipesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetRecipeCategoryAssignmentsForRecipesResponseDto>> GetRecipeCategoryAssignmentsForRecipesDetailsAsync(int recipesId, int recipeCategoryAssignmentsId)
        {
            var returnValue = await _repository.GetRecipeCategoryAssignmentsForRecipesDetailsAsync(recipesId, recipeCategoryAssignmentsId);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> DeactivateAsync(int recipesId, DeactivateRequestDto updateRequest)
        {
            var returnValue = await _repository.DeactivateAsync(recipesId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}