using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demo-kahve.Common.Models; using  QuickCode . Demo
-kahve.ProductionModuleModule.Domain.Entities; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Dtos.GrindingProcess; using  QuickCode . Demo
-kahve.ProductionModuleModule.Domain.Enums;
namespace QuickCode.Demo - kahve . ProductionModuleModule . Application . Services . GrindingProcess {
    public partial class GrindingProcessService : IGrindingProcessService
    {
        private readonly ILogger<GrindingProcessService> _logger;
        private readonly IGrindingProcessRepository _repository;
        public GrindingProcessService(ILogger<GrindingProcessService> logger, IGrindingProcessRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<GrindingProcessDto>> InsertAsync(GrindingProcessDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(GrindingProcessDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, GrindingProcessDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GrindingProcessDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<GrindingProcessDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByRoastingProcessIdResponseDto>>> GetByRoastingProcessIdAsync(int grindingProcessesRoastingProcessId, int? page, int? size)
        {
            var returnValue = await _repository.GetByRoastingProcessIdAsync(grindingProcessesRoastingProcessId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByStatusResponseDto>>> GetByStatusAsync(ProcessStatus grindingProcessesProcessStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetByStatusAsync(grindingProcessesProcessStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetPackagingProcessesForGrindingProcessesResponseDto>>> GetPackagingProcessesForGrindingProcessesAsync(int grindingProcessesId)
        {
            var returnValue = await _repository.GetPackagingProcessesForGrindingProcessesAsync(grindingProcessesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetPackagingProcessesForGrindingProcessesResponseDto>> GetPackagingProcessesForGrindingProcessesDetailsAsync(int grindingProcessesId, int packagingProcessesId)
        {
            var returnValue = await _repository.GetPackagingProcessesForGrindingProcessesDetailsAsync(grindingProcessesId, packagingProcessesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> UpdateStatusAsync(int grindingProcessesId, UpdateStatusRequestDto updateRequest)
        {
            var returnValue = await _repository.UpdateStatusAsync(grindingProcessesId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}