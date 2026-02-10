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
    public partial interface IRecipeCategoryService
    {
        Task<Response<RecipeCategoryDto>> InsertAsync(RecipeCategoryDto request);
        Task<Response<bool>> DeleteAsync(RecipeCategoryDto request);
        Task<Response<bool>> UpdateAsync(int id, RecipeCategoryDto request);
        Task<Response<List<RecipeCategoryDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<RecipeCategoryDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool recipeCategoriesIsActive, int? page, int? size);
        Task<Response<List<GetRecipeCategoryAssignmentsForRecipeCategoriesResponseDto>>> GetRecipeCategoryAssignmentsForRecipeCategoriesAsync(int recipeCategoriesId);
        Task<Response<GetRecipeCategoryAssignmentsForRecipeCategoriesResponseDto>> GetRecipeCategoryAssignmentsForRecipeCategoriesDetailsAsync(int recipeCategoriesId, int recipeCategoryAssignmentsId);
        Task<Response<int>> DeactivateAsync(int recipeCategoriesId, DeactivateRequestDto updateRequest);
    }
}