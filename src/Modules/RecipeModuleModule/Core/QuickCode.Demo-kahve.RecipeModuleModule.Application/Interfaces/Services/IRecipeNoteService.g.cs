using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demo-kahve.Common.Models; using  QuickCode . Demo
-kahve.RecipeModuleModule.Domain.Entities; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Dtos.RecipeNote;
namespace QuickCode.Demo - kahve . RecipeModuleModule . Application . Services . RecipeNote {
    public partial interface IRecipeNoteService
    {
        Task<Response<RecipeNoteDto>> InsertAsync(RecipeNoteDto request);
        Task<Response<bool>> DeleteAsync(RecipeNoteDto request);
        Task<Response<bool>> UpdateAsync(int id, RecipeNoteDto request);
        Task<Response<List<RecipeNoteDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<RecipeNoteDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByRecipeIdResponseDto>>> GetByRecipeIdAsync(int recipeNotesRecipeId, int? page, int? size);
    }
}