using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demo-kahve.Common.Models; using  QuickCode . Demo
-kahve.RecipeModuleModule.Domain.Entities; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Dtos.RecipeImage;
namespace QuickCode.Demo - kahve . RecipeModuleModule . Application . Services . RecipeImage {
    public partial interface IRecipeImageService
    {
        Task<Response<RecipeImageDto>> InsertAsync(RecipeImageDto request);
        Task<Response<bool>> DeleteAsync(RecipeImageDto request);
        Task<Response<bool>> UpdateAsync(int id, RecipeImageDto request);
        Task<Response<List<RecipeImageDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<RecipeImageDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByRecipeIdResponseDto>>> GetByRecipeIdAsync(int recipeImagesRecipeId, int? page, int? size);
    }
}