using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demo-kahve.Common.Models; using  QuickCode . Demo
-kahve.RecipeModuleModule.Domain.Entities; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Dtos.RecipeCategoryAssignment;
namespace QuickCode.Demo - kahve . RecipeModuleModule . Application . Services . RecipeCategoryAssignment {
    public partial interface IRecipeCategoryAssignmentService
    {
        Task<Response<RecipeCategoryAssignmentDto>> InsertAsync(RecipeCategoryAssignmentDto request);
        Task<Response<bool>> DeleteAsync(RecipeCategoryAssignmentDto request);
        Task<Response<bool>> UpdateAsync(int id, RecipeCategoryAssignmentDto request);
        Task<Response<List<RecipeCategoryAssignmentDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<RecipeCategoryAssignmentDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByRecipeIdResponseDto>>> GetByRecipeIdAsync(int recipeCategoryAssignmentsRecipeId, int? page, int? size);
        Task<Response<List<GetByCategoryIdResponseDto>>> GetByCategoryIdAsync(int recipeCategoryAssignmentsCategoryId, int? page, int? size);
    }
}