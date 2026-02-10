using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demo-kahve.Common.Models; using  QuickCode . Demo
-kahve.RecipeModuleModule.Domain.Entities; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Dtos.RecipeIngredient;
namespace QuickCode.Demo - kahve . RecipeModuleModule . Application . Services . RecipeIngredient {
    public partial interface IRecipeIngredientService
    {
        Task<Response<RecipeIngredientDto>> InsertAsync(RecipeIngredientDto request);
        Task<Response<bool>> DeleteAsync(RecipeIngredientDto request);
        Task<Response<bool>> UpdateAsync(int id, RecipeIngredientDto request);
        Task<Response<List<RecipeIngredientDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<RecipeIngredientDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByRecipeIdResponseDto>>> GetByRecipeIdAsync(int recipeIngredientsRecipeId, int? page, int? size);
    }
}