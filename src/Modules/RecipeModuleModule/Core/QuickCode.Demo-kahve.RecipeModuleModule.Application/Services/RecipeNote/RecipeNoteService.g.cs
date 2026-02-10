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
    public partial class RecipeNoteService : IRecipeNoteService
    {
        private readonly ILogger<RecipeNoteService> _logger;
        private readonly IRecipeNoteRepository _repository;
        public RecipeNoteService(ILogger<RecipeNoteService> logger, IRecipeNoteRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<RecipeNoteDto>> InsertAsync(RecipeNoteDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(RecipeNoteDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, RecipeNoteDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<RecipeNoteDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<RecipeNoteDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByRecipeIdResponseDto>>> GetByRecipeIdAsync(int recipeNotesRecipeId, int? page, int? size)
        {
            var returnValue = await _repository.GetByRecipeIdAsync(recipeNotesRecipeId, page, size);
            return returnValue.ToResponse();
        }
    }
}