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
    public partial interface IRecipeService
    {
        Task<Response<RecipeDto>> InsertAsync(RecipeDto request);
        Task<Response<bool>> DeleteAsync(RecipeDto request);
        Task<Response<bool>> UpdateAsync(int id, RecipeDto request);
        Task<Response<List<RecipeDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<RecipeDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool recipesIsActive, int? page, int? size);
        Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string recipesRecipeName, int? page, int? size);
        Task<Response<List<GetRecipeIngredientsForRecipesResponseDto>>> GetRecipeIngredientsForRecipesAsync(int recipesId);
        Task<Response<GetRecipeIngredientsForRecipesResponseDto>> GetRecipeIngredientsForRecipesDetailsAsync(int recipesId, int recipeIngredientsId);
        Task<Response<List<GetRecipeEquipmentsForRecipesResponseDto>>> GetRecipeEquipmentsForRecipesAsync(int recipesId);
        Task<Response<GetRecipeEquipmentsForRecipesResponseDto>> GetRecipeEquipmentsForRecipesDetailsAsync(int recipesId, int recipeEquipmentsId);
        Task<Response<List<GetRecipeNotesForRecipesResponseDto>>> GetRecipeNotesForRecipesAsync(int recipesId);
        Task<Response<GetRecipeNotesForRecipesResponseDto>> GetRecipeNotesForRecipesDetailsAsync(int recipesId, int recipeNotesId);
        Task<Response<List<GetRecipeImagesForRecipesResponseDto>>> GetRecipeImagesForRecipesAsync(int recipesId);
        Task<Response<GetRecipeImagesForRecipesResponseDto>> GetRecipeImagesForRecipesDetailsAsync(int recipesId, int recipeImagesId);
        Task<Response<List<GetRecipeCategoryAssignmentsForRecipesResponseDto>>> GetRecipeCategoryAssignmentsForRecipesAsync(int recipesId);
        Task<Response<GetRecipeCategoryAssignmentsForRecipesResponseDto>> GetRecipeCategoryAssignmentsForRecipesDetailsAsync(int recipesId, int recipeCategoryAssignmentsId);
        Task<Response<int>> DeactivateAsync(int recipesId, DeactivateRequestDto updateRequest);
    }
}