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
    public partial class RecipeEquipmentService : IRecipeEquipmentService
    {
        private readonly ILogger<RecipeEquipmentService> _logger;
        private readonly IRecipeEquipmentRepository _repository;
        public RecipeEquipmentService(ILogger<RecipeEquipmentService> logger, IRecipeEquipmentRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<RecipeEquipmentDto>> InsertAsync(RecipeEquipmentDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(RecipeEquipmentDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, RecipeEquipmentDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<RecipeEquipmentDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<RecipeEquipmentDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByRecipeIdResponseDto>>> GetByRecipeIdAsync(int recipeEquipmentsRecipeId, int? page, int? size)
        {
            var returnValue = await _repository.GetByRecipeIdAsync(recipeEquipmentsRecipeId, page, size);
            return returnValue.ToResponse();
        }
    }
}