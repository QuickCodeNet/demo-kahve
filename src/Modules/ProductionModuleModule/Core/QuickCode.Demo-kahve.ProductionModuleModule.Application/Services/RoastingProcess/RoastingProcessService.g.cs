using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demo-kahve.Common.Models; using  QuickCode . Demo
-kahve.ProductionModuleModule.Domain.Entities; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Dtos.RoastingProcess; using  QuickCode . Demo
-kahve.ProductionModuleModule.Domain.Enums;
namespace QuickCode.Demo - kahve . ProductionModuleModule . Application . Services . RoastingProcess {
    public partial class RoastingProcessService : IRoastingProcessService
    {
        private readonly ILogger<RoastingProcessService> _logger;
        private readonly IRoastingProcessRepository _repository;
        public RoastingProcessService(ILogger<RoastingProcessService> logger, IRoastingProcessRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<RoastingProcessDto>> InsertAsync(RoastingProcessDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(RoastingProcessDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, RoastingProcessDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<RoastingProcessDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<RoastingProcessDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByBeanBatchIdResponseDto>>> GetByBeanBatchIdAsync(int roastingProcessesBeanBatchId, int? page, int? size)
        {
            var returnValue = await _repository.GetByBeanBatchIdAsync(roastingProcessesBeanBatchId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByStatusResponseDto>>> GetByStatusAsync(ProcessStatus roastingProcessesProcessStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetByStatusAsync(roastingProcessesProcessStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetGrindingProcessesForRoastingProcessesResponseDto>>> GetGrindingProcessesForRoastingProcessesAsync(int roastingProcessesId)
        {
            var returnValue = await _repository.GetGrindingProcessesForRoastingProcessesAsync(roastingProcessesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetGrindingProcessesForRoastingProcessesResponseDto>> GetGrindingProcessesForRoastingProcessesDetailsAsync(int roastingProcessesId, int grindingProcessesId)
        {
            var returnValue = await _repository.GetGrindingProcessesForRoastingProcessesDetailsAsync(roastingProcessesId, grindingProcessesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> UpdateStatusAsync(int roastingProcessesId, UpdateStatusRequestDto updateRequest)
        {
            var returnValue = await _repository.UpdateStatusAsync(roastingProcessesId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}