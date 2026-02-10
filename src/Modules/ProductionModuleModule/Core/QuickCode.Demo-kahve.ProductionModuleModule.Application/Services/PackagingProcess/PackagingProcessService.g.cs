using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demo-kahve.Common.Models; using  QuickCode . Demo
-kahve.ProductionModuleModule.Domain.Entities; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Interfaces.Repositories; using  QuickCode . Demo
-kahve.ProductionModuleModule.Application.Dtos.PackagingProcess; using  QuickCode . Demo
-kahve.ProductionModuleModule.Domain.Enums;
namespace QuickCode.Demo - kahve . ProductionModuleModule . Application . Services . PackagingProcess {
    public partial class PackagingProcessService : IPackagingProcessService
    {
        private readonly ILogger<PackagingProcessService> _logger;
        private readonly IPackagingProcessRepository _repository;
        public PackagingProcessService(ILogger<PackagingProcessService> logger, IPackagingProcessRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<PackagingProcessDto>> InsertAsync(PackagingProcessDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(PackagingProcessDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, PackagingProcessDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<PackagingProcessDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<PackagingProcessDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByGrindingProcessIdResponseDto>>> GetByGrindingProcessIdAsync(int packagingProcessesGrindingProcessId, int? page, int? size)
        {
            var returnValue = await _repository.GetByGrindingProcessIdAsync(packagingProcessesGrindingProcessId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByStatusResponseDto>>> GetByStatusAsync(ProcessStatus packagingProcessesProcessStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetByStatusAsync(packagingProcessesProcessStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> UpdateStatusAsync(int packagingProcessesId, UpdateStatusRequestDto updateRequest)
        {
            var returnValue = await _repository.UpdateStatusAsync(packagingProcessesId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}