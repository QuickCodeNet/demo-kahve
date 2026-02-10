using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demo-kahve.Common.Models; using  QuickCode . Demo
-kahve.RecipeModuleModule.Domain.Entities; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.RecipeModuleModule.Application.Dtos.RecipeEquipment;
namespace QuickCode.Demo - kahve . RecipeModuleModule . Application . Services . RecipeEquipment {
    public partial interface IRecipeEquipmentService
    {
        Task<Response<RecipeEquipmentDto>> InsertAsync(RecipeEquipmentDto request);
        Task<Response<bool>> DeleteAsync(RecipeEquipmentDto request);
        Task<Response<bool>> UpdateAsync(int id, RecipeEquipmentDto request);
        Task<Response<List<RecipeEquipmentDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<RecipeEquipmentDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByRecipeIdResponseDto>>> GetByRecipeIdAsync(int recipeEquipmentsRecipeId, int? page, int? size);
    }
}